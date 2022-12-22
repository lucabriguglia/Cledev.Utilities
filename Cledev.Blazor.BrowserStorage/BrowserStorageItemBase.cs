using System;

namespace Cledev.Blazor.BrowserStorage;

public abstract class BrowserStorageItemBase : IBrowserStorageItem
{
    public string Key { get; set; } = Guid.NewGuid().ToString();
}