﻿using Core.Code.Extensions;
using Core.Consts;
using Data.Entities.User;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Web.ViewModels.User;

namespace Web.Components.User;

/// <summary>
/// Renders an alert box summary of when the user's next deload week will occur.
/// </summary>
public class EditViewComponent(UserRepo userRepo) : ViewComponent
{
    /// <summary>
    /// For routing
    /// </summary>
    public const string Name = "Edit";

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.User.User? user = null)
    {
        user ??= await userRepo.GetUser(UserConsts.DemoUser, UserConsts.DemoToken, includeExerciseVariations: true, includeMuscles: true, includeFrequencies: true, allowDemoUser: true);
        if (user == null)
        {
            return Content("");
        }

        var token = await userRepo.AddUserToken(user, durationDays: 1);
        return View("Edit", await PopulateUserEditViewModel(new UserEditViewModel(user, token)));
    }

    private async Task<UserEditViewModel> PopulateUserEditViewModel(UserEditViewModel viewModel)
    {
        viewModel.UserFrequencies = (viewModel.UserFrequencies?.NullIfEmpty() ?? (await userRepo.GetUpcomingRotations(viewModel.User, viewModel.User.Frequency)).OrderBy(f => f.Id).Select(f => new UserEditFrequencyViewModel(f))).ToList();
        while (viewModel.UserFrequencies.Count < UserConsts.MaxUserFrequencies)
        {
            viewModel.UserFrequencies.Add(new UserEditFrequencyViewModel() { Day = viewModel.UserFrequencies.Count + 1 });
        }

        foreach (var muscleGroup in UserMuscleMobility.MuscleTargets.Keys
            .OrderBy(mg => mg.GetSingleDisplayName(EnumExtensions.DisplayNameType.GroupName))
            .ThenBy(mg => mg.GetSingleDisplayName()))
        {
            var userMuscleMobility = viewModel.User.UserMuscleMobilities.SingleOrDefault(umm => umm.MuscleGroup == muscleGroup);
            viewModel.UserMuscleMobilities.Add(userMuscleMobility != null ? new UserEditMuscleMobilityViewModel(userMuscleMobility) : new UserEditMuscleMobilityViewModel()
            {
                UserId = viewModel.User.Id,
                MuscleGroup = muscleGroup,
                Count = UserMuscleMobility.MuscleTargets.TryGetValue(muscleGroup, out int countTmp) ? countTmp : 0
            });
        }

        foreach (var muscleGroup in UserMuscleFlexibility.MuscleTargets.Keys
            .OrderBy(mg => mg.GetSingleDisplayName(EnumExtensions.DisplayNameType.GroupName))
            .ThenBy(mg => mg.GetSingleDisplayName()))
        {
            var userMuscleFlexibility = viewModel.User.UserMuscleFlexibilities.SingleOrDefault(umm => umm.MuscleGroup == muscleGroup);
            viewModel.UserMuscleFlexibilities.Add(userMuscleFlexibility != null ? new UserEditMuscleFlexibilityViewModel(userMuscleFlexibility) : new UserEditMuscleFlexibilityViewModel()
            {
                UserId = viewModel.User.Id,
                MuscleGroup = muscleGroup,
                Count = UserMuscleFlexibility.MuscleTargets.TryGetValue(muscleGroup, out int countTmp) ? countTmp : 0
            });
        }

        return viewModel;
    }
}
