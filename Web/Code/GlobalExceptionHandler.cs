﻿using Core.Consts;
using Core.Models.User;
using Data;
using Data.Entities.Newsletter;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;

namespace Web.Code;

public class GlobalExceptionHandler(IServiceScopeFactory serviceScopeFactory) : IExceptionHandler
{
    private static DateOnly Today => DateOnly.FromDateTime(DateTime.UtcNow);

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        try
        {
            if (!DebugConsts.IsDebug)
            {
                await SendExceptionEmails(exception, cancellationToken);
            }
        }
        catch { }

        // Return false to continue with the default behavior
        // - or - return true to signal that this exception is handled
        return false;
    }

    private async Task SendExceptionEmails(Exception exception, CancellationToken cancellationToken)
    {
        using var scope = serviceScopeFactory.CreateScope();
        using var context = scope.ServiceProvider.GetRequiredService<CoreContext>();

        // Send just one a day.
        var oneSentToday = await context.UserEmails.Where(ue => ue.Date == Today && ue.Subject == NewsletterConsts.SubjectException).AnyAsync(cancellationToken);
        if (!oneSentToday)
        {
            var devUsers = await context.Users.Where(u => u.Features.HasFlag(Features.Dev)).ToListAsync(cancellationToken);
            if (devUsers != null)
            {
                foreach (var devUser in devUsers)
                {
                    context.UserEmails.Add(new UserEmail(devUser)
                    {
                        Subject = NewsletterConsts.SubjectException,
                        Body = exception.ToString(),
                    });
                }

                await context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}