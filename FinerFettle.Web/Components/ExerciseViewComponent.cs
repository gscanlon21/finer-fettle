﻿using FinerFettle.Web.Data;
using FinerFettle.Web.Models.Exercise;
using FinerFettle.Web.Models.User;
using FinerFettle.Web.ViewModels.Newsletter;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Numerics;

namespace FinerFettle.Web.Components
{
    public class ExerciseViewComponent : ViewComponent
    {
        private readonly CoreContext _context;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public ExerciseViewComponent(CoreContext context, IServiceScopeFactory serviceScopeFactory)
        {
            _context = context;
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(User? user, ExerciseViewModel exercise, bool verbose = false)
        {
            if (exercise == null)
            {
                return Content(string.Empty);
            }

            if (user != null)
            {
                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    var coreContext = scope.ServiceProvider.GetRequiredService<CoreContext>();

                    exercise.UserProgression = await coreContext.UserProgressions
                        .FirstOrDefaultAsync(p => p.UserId == user.Id && p.ExerciseId == exercise.Exercise.Exercise.Id);

                    if (exercise.UserProgression == null)
                    {
                        exercise.UserProgression = new ExerciseUserProgression()
                        {
                            ExerciseId = exercise.Exercise.Exercise.Id,
                            UserId = user.Id,
                            Progression = 50 // FIXME: Magic int is magic. But really just the mid progression level.
                        };

                        coreContext.UserProgressions.Add(exercise.UserProgression);
                        await coreContext.SaveChangesAsync();
                    }
                }
            }

            // You should be able to progress above an exercise that has a max progression set
            exercise.HasHigherProgressionVariation = exercise.Intensity.MaxProgression != null 
                && exercise.UserProgression != null && exercise.UserProgression.Progression < 100;

            // You should be able to progress below an exercise that has a min progression set
            exercise.HasLowerProgressionVariation = exercise.Intensity.MinProgression != null 
                && exercise.UserProgression != null && exercise.UserProgression.Progression > 0;

            exercise.EquipmentGroups = (await _context.Variations
                .Include(v => v.EquipmentGroups)
                .ThenInclude(e => e.Equipment)
                .FirstAsync(v => v.Id == exercise.Exercise.Id)).EquipmentGroups;

            exercise.Verbose = verbose;

            return View("Exercise", exercise);
        }
    }
}
