﻿using System;
using System.Linq;
using System.Windows;
#if WPF
using System.Windows.Controls;
using xaml = System.Windows.Controls;
#elif XAMARIN
using Xamarin.Forms;
using Button = AdaptiveCards.Rendering.ContentButton;
#endif

namespace AdaptiveCards.Rendering
{

    public partial class XamlRenderer
        : AdaptiveRenderer<FrameworkElement, RenderContext>
    {

        protected Button CreateActionButton(ActionBase action, RenderContext renderContext)
        {
#if WPF
            ActionOptions styling = renderContext.Options.Actions;
            var uiButton = new Button()
            {
                Background = this.GetColorBrush(styling.BackgroundColor),
                Margin = new Thickness(styling.Margin.Left, styling.Margin.Top, styling.Margin.Right, styling.Margin.Bottom),
                HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch,
                BorderBrush = this.GetColorBrush(styling.BorderColor)
            };
            uiButton.Style = this.GetStyle($"Adaptive.{action.Type}");

            xaml.TextBlock uiTitle = new xaml.TextBlock()
            {
                Text = action.Title,
                FontWeight = FontWeight.FromOpenTypeWeight(styling.FontWeight),
                FontSize = styling.FontSize,
                Foreground = this.GetColorBrush(styling.TextColor),
                Margin = new Thickness(styling.Padding.Left, styling.Padding.Top, styling.Padding.Right, styling.Padding.Bottom) ,
            };
            uiTitle.Style = this.GetStyle($"Adaptive.Action.Title");
            uiButton.Content = uiTitle;
            string name = this.GetType().Name.Replace("Action", String.Empty);
            return uiButton;

#elif XAMARIN
            var uiButton = new Button();
            // TODO: button styling
            uiButton.Text = action.Title;
            string name = this.GetType().Name.Replace("Action", String.Empty);
            uiButton.Style = this.GetStyle($"Adaptive.Action.{name}");
            return uiButton;
#endif
        }
    }
}