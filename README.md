# Sonner for Blazor

An opinionated toast component for Blazor. A port of Emil Kowalski's [Sonner](https://sonner.emilkowal.ski/).

## Installation

```bash
dotnet add package Blazor.Sonner
```

Register the service in the DI container.

```csharp
using Blazor.Sonner.Extensions;

// ...

builder.Services.AddSonner();
```

Add the styles to the HTML.

```html
<link href="_content/Blazor.Sonner/styles.css" rel="stylesheet" />
```

## Usage

Render the toaster in the root of your app.

```razor
@using Blazor.Sonner
@inject ToastService Toast

<Toaster />
<button @onclick="@(() => Toast.Show("My first toast"))">
    Give me a toast
</button>
```

## API Reference _(in progress)_

### ToastService

| Method  | Description |
| ------------- | -------------- |
| Show | Displays a default toast with the specified title and optional data. |
| Success | Displays a success toast with the specified title and optional data. |
| Warning | Displays a warning toast with the specified title and optional data. |
| Error | Displays an error toast with the specified title and optional data. |
| Info | Displays an informational toast with the specified title and optional data. |
| RemoveAll | Removes all currently displayed toasts. |

### Toaster (Global settings)

| Parameter  | Description | Type | Default |
| ------------- | -------------- | ------------- | ------------- |
| Id | Gets or sets the unique identifier for the toaster instance.  | `string?`  | `-`  |
| Position | Gets or sets the position on the screen where toasts are displayed. | `ToastPosition`  | `ToastPosition.BottomRight`  |
| Duration | Gets or sets the duration each toast is displayed before it is automatically dismissed. | `TimeSpan` | `4000` ms |
| VisibleToasts | Gets or sets the maximum number of visible toasts. | `int` | `3` |
| Gap | Gets or sets the spacing in pixels between toasts. | `int` | `14` |
| Offset | Gets or sets the offset from the screen edges. | `Offset` | `-` |
| MobileOffset | Gets or sets the offset from the screen edges on mobile devices. | `Offset` | `-` |
| Expand | Gets or sets a value indicating whether toasts should be expanded by default. | `bool` | `false` |
| CloseButton | Gets or sets a value indicating whether to show a close button on toasts. | `bool` | `false` |
| RichColors | Gets or sets a value indicating whether to enable rich color styling for toasts. | `bool` | `false` |
| Dir | Gets or sets the document direction for the toast layout. | `DocumentDirection` | `DocumentDirection.Auto` |
