﻿using Tutor.Client.APIAccess.Abstractions;
using Tutor.Shared.Dtos;

namespace Tutor.Client.APIAccess;

internal class AdvertisementsClient : APIClient, IAdvertisementsClient
{
    public AdvertisementsClient(HttpClient httpClient) : base(httpClient)
    {
    }

    public async Task<APIResponse<PagedResult<AdvertisementDto>>> GetAdvertisementsAsync()
        => await GetAsync<PagedResult<AdvertisementDto>>("/api/advertisements");
}
