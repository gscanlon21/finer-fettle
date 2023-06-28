﻿using Core.Models.Footnote;
using Core.Models.Options;
using Lib.ViewModels.Newsletter;
using Lib.ViewModels.User;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;

namespace Lib.Services;

internal class NewsletterService
{
    /// <summary>
    /// Today's date in UTC.
    /// </summary>
    private static DateOnly Today => DateOnly.FromDateTime(DateTime.UtcNow);

    /// <summary>
    /// This week's Sunday date in UTC.
    /// </summary>
    protected static DateOnly StartOfWeek => Today.AddDays(-1 * (int)Today.DayOfWeek);

    private readonly HttpClient _httpClient;
    private readonly IOptions<SiteSettings> _siteSettings;

    public NewsletterService(IHttpClientFactory httpClientFactory, IOptions<SiteSettings> siteSettings)
    {
        _siteSettings = siteSettings;
        _httpClient = httpClientFactory.CreateClient();
        if (_httpClient.BaseAddress != _siteSettings.Value.ApiUri)
        {
            _httpClient.BaseAddress = _siteSettings.Value.ApiUri;
        }
    }

    public async Task<IList<ViewModels.Footnote.FootnoteViewModel>?> GetFootnotes(UserNewsletterViewModel user, int count = 1, FootnoteType ofType = FootnoteType.All)
    {
        // Only show the types the user wants to see
        ofType &= user.FootnoteType;

        return await _httpClient.GetFromJsonAsync<List<ViewModels.Footnote.FootnoteViewModel>>($"{_siteSettings.Value.ApiUri.AbsolutePath}/newsletter/GetFootnotes?count={count}&ofType={ofType}");
    }

    /// <summary>
    /// Root route for building out the the workout routine newsletter.
    /// </summary>
    public async Task<NewsletterViewModel?> Newsletter(string email = "demo@aworkoutaday.com", string token = "00000000-0000-0000-0000-000000000000", DateOnly? date = null)
    {
        return await _httpClient.GetFromJsonAsync<NewsletterViewModel>($"{_siteSettings.Value.ApiUri.AbsolutePath}/newsletter/Newsletter?email={email}&token={token}&date={date}");
    }
}
