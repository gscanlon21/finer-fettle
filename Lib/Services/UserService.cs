﻿using Core.Models.Options;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;

namespace Lib.Services;

/// <summary>
/// User helpers.
/// </summary>
public class UserService
{
    private readonly HttpClient _httpClient;
    private readonly IOptions<SiteSettings> _siteSettings;

    public UserService(IHttpClientFactory httpClientFactory, IOptions<SiteSettings> siteSettings)
    {
        _siteSettings = siteSettings;
        _httpClient = httpClientFactory.CreateClient();
        if (_httpClient.BaseAddress != _siteSettings.Value.ApiUri)
        {
            _httpClient.BaseAddress = _siteSettings.Value.ApiUri;
        }
    }

    public async Task<IList<ViewModels.Newsletter.UserWorkoutViewModel>?> GetWorkouts(string email, string token)
    {
        return await _httpClient.GetFromJsonAsync<List<ViewModels.Newsletter.UserWorkoutViewModel>>($"{_siteSettings.Value.ApiUri.AbsolutePath}/User/Workouts?email={Uri.EscapeDataString(email)}&token={Uri.EscapeDataString(token)}");
    }
}

