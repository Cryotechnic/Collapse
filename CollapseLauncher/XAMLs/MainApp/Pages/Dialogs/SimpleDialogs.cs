﻿using CollapseLauncher.Statics;
using Microsoft.UI.Text;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Documents;
using Microsoft.UI.Xaml.Media;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Hi3Helper.Data.ConverterTool;
using static Hi3Helper.Locale;
using static Hi3Helper.Shared.Region.LauncherConfig;

namespace CollapseLauncher.Dialogs
{
    public static class SimpleDialogs
    {
        public static async Task<ContentDialogResult> Dialog_DeltaPatchFileDetected(UIElement Content, string sourceVer, string targetVer) =>
               await SpawnDialog(
                       Lang._Dialogs.DeltaPatchDetectedTitle,
                       string.Format(Lang._Dialogs.DeltaPatchDetectedSubtitle, sourceVer, targetVer),
                       Content,
                       Lang._Misc.Cancel,
                       Lang._Misc.Yes,
                       Lang._Misc.No,
                       ContentDialogButton.Primary
                   );

        public static async Task<ContentDialogResult> Dialog_PreDownloadPackageVerified(UIElement Content) =>
               await SpawnDialog(
                       Lang._Dialogs.PreloadVerifiedTitle,
                       Lang._Dialogs.PreloadVerifiedSubtitle,
                       Content,
                       Lang._Misc.Close,
                       null,
                       null,
                       ContentDialogButton.Secondary
                   );

        public static async Task<ContentDialogResult> Dialog_PreviousDeltaPatchInstallFailed(UIElement Content) =>
            await SpawnDialog(
                    Lang._Dialogs.DeltaPatchPrevFailedTitle,
                    Lang._Dialogs.DeltaPatchPrevFailedSubtitle,
                    Content,
                    null,
                    Lang._Misc.Yes,
                    Lang._Misc.No
                );

        public static async Task<ContentDialogResult> Dialog_PreviousGameConversionFailed(UIElement Content) =>
            await SpawnDialog(
                    Lang._Dialogs.GameConversionPrevFailedTitle,
                    Lang._Dialogs.GameConversionPrevFailedSubtitle,
                    Content,
                    null,
                    Lang._Misc.Yes,
                    Lang._Misc.No
                );

        public static async Task<ContentDialogResult> Dialog_InstallationLocation(UIElement Content) =>
            await SpawnDialog(
                    Lang._Dialogs.LocateInstallTitle,
                    Lang._Dialogs.LocateInstallSubtitle,
                    Content,
                    Lang._Misc.Cancel,
                    Lang._Misc.UseDefaultDir,
                    Lang._Misc.LocateDir
                );

        public static async Task<ContentDialogResult> Dialog_InsufficientWritePermission(UIElement Content, string path) =>
            await SpawnDialog(
                    Lang._Dialogs.UnauthorizedDirTitle,
                    string.Format(Lang._Dialogs.UnauthorizedDirSubtitle, path),
                    Content,
                    Lang._Misc.Okay,
                    null,
                    null
                );

        public static async Task<int> Dialog_ChooseAudioLanguage(UIElement Content, List<string> langlist)
        {
            // Default: 2 (Japanese)
            int index = 2;
            StackPanel Panel = new StackPanel();
            ComboBox LangBox = new ComboBox()
            {
                PlaceholderText = Lang._Dialogs.ChooseAudioLangSelectPlaceholder,
                Width = 256,
                ItemsSource = langlist,
                SelectedIndex = index,
                HorizontalAlignment = HorizontalAlignment.Center,
            };
            Panel.Children.Add(new TextBlock()
            {
                Text = Lang._Dialogs.ChooseAudioLangSubtitle,
                TextWrapping = TextWrapping.Wrap,
                Margin = new Thickness(0, 0, 0, 16)
            });
            Panel.Children.Add(LangBox);
            await SpawnDialog(Lang._Dialogs.ChooseAudioLangTitle, Panel, Content, null, Lang._Misc.Next, null);

            index = LangBox.SelectedIndex;

            return index;
        }

        public static async Task<ContentDialogResult> Dialog_GraphicsVeryHighWarning(UIElement Content) =>
            await SpawnDialog(
                    Lang._Dialogs.ExtremeGraphicsSettingsWarnTitle,
                    Lang._Dialogs.ExtremeGraphicsSettingsWarnSubtitle,
                    Content,
                    null,
                    Lang._Misc.YesIHaveBeefyPC,
                    Lang._Misc.No,
                    ContentDialogButton.Secondary
                );

        public static async Task<ContentDialogResult> Dialog_LocateDownloadedConvertRecipe(UIElement Content, string FileName)
        {
            TextBlock texts = new TextBlock { TextWrapping = TextWrapping.Wrap };
            texts.Inlines.Add(new Run { Text = Lang._Dialogs.CookbookLocateSubtitle1 });
            texts.Inlines.Add(new Hyperlink()
            {
                Inlines = { new Run { Text = Lang._Dialogs.CookbookLocateSubtitle2, FontWeight = FontWeights.Bold, Foreground = (SolidColorBrush)Application.Current.Resources["AccentColor"] } },
                NavigateUri = new Uri("https://www.mediafire.com/folder/gb09r9fw0ndxb/Hi3ConversionRecipe"),
            });
            texts.Inlines.Add(new Run { Text = Lang._Dialogs.CookbookLocateSubtitle3 });
            texts.Inlines.Add(new Run { Text = $" {Lang._Misc.Next} ", FontWeight = FontWeights.Bold });
            texts.Inlines.Add(new Run { Text = Lang._Dialogs.CookbookLocateSubtitle5 });
            texts.Inlines.Add(new Run { Text = Lang._Dialogs.CookbookLocateSubtitle6, FontWeight = FontWeights.Bold });
            texts.Inlines.Add(new Run { Text = Lang._Dialogs.CookbookLocateSubtitle7 });
            texts.Inlines.Add(new Run { Text = FileName, FontWeight = FontWeights.Bold });
            return await SpawnDialog(
                    Lang._Dialogs.CookbookLocateTitle,
                    texts,
                    Content,
                    Lang._Misc.Cancel,
                    Lang._Misc.Next,
                    null,
                    ContentDialogButton.Primary
                );
        }

        public static async Task<ContentDialogResult> Dialog_ChangeReleaseChannel(string ChannelName, UIElement Content)
        {
            TextBlock texts = new TextBlock { TextWrapping = TextWrapping.Wrap };
            texts.Inlines.Add(new Run { Text = Lang._Dialogs.ReleaseChannelChangeSubtitle1 });
            texts.Inlines.Add(new Run { Text = $" {ChannelName}", FontWeight = FontWeights.Bold });
            texts.Inlines.Add(new Run { Text = "\r\n\r\n" });
            texts.Inlines.Add(new Run { Text = Lang._Dialogs.ReleaseChannelChangeSubtitle2 + "\r\n", FontSize = 18, FontWeight = FontWeights.Bold });
            texts.Inlines.Add(new Run { Text = Lang._Dialogs.ReleaseChannelChangeSubtitle3 });
            return await SpawnDialog(
                    Lang._Dialogs.ReleaseChannelChangeTitle,
                    texts,
                    Content,
                    Lang._Misc.Cancel,
                    Lang._Misc.OkayHappy,
                    null,
                    ContentDialogButton.Primary
                );
        }

        public static async Task<ContentDialogResult> Dialog_ExistingInstallation(UIElement Content) =>
            await SpawnDialog(
                    Lang._Dialogs.ExistingInstallTitle,
                    string.Format(Lang._Dialogs.ExistingInstallSubtitle, PageStatics._GameVersion.GamePreset.ActualGameDataLocation),
                    Content,
                    Lang._Misc.Cancel,
                    Lang._Misc.YesMigrateIt,
                    Lang._Misc.NoKeepInstallIt
            );

        public static async Task<ContentDialogResult> Dialog_ExistingInstallationBetterLauncher(UIElement Content, string gamePath) =>
            await SpawnDialog(
                    Lang._Dialogs.ExistingInstallBHI3LTitle,
                    string.Format(Lang._Dialogs.ExistingInstallBHI3LSubtitle, gamePath),
                    Content,
                    Lang._Misc.Cancel,
                    Lang._Misc.YesMigrateIt,
                    Lang._Misc.NoKeepInstallIt
            );

        public static async Task<ContentDialogResult> Dialog_ExistingInstallationSteam(UIElement Content) =>
            await SpawnDialog(
                    Lang._Dialogs.ExistingInstallSteamTitle,
                    string.Format(Lang._Dialogs.ExistingInstallSteamSubtitle, GamePathOnSteam),
                    Content,
                    Lang._Misc.Cancel,
                    Lang._Misc.YesMigrateIt,
                    Lang._Misc.NoKeepInstallIt
            );

        public static async Task<ContentDialogResult> Dialog_SteamConversionNoPermission(UIElement Content) =>
            await SpawnDialog(
                    Lang._Dialogs.SteamConvertNeedMigrateTitle,
                    Lang._Dialogs.SteamConvertNeedMigrateSubtitle,
                    Content,
                    Lang._Misc.Cancel,
                    Lang._Misc.Yes,
                    Lang._Misc.NoOtherLocation
            );

        public static async Task<ContentDialogResult> Dialog_SteamConversionDownloadDialog(UIElement Content, string SizeString) =>
            await SpawnDialog(
                    Lang._Dialogs.SteamConvertIntegrityDoneTitle,
                    Lang._Dialogs.SteamConvertIntegrityDoneSubtitle,
                    Content,
                    Lang._Misc.Cancel,
                    Lang._Misc.Yes,
                    null
            );

        public static async Task<ContentDialogResult> Dialog_SteamConversionFailedDialog(UIElement Content) =>
            await SpawnDialog(
                    Lang._Dialogs.SteamConvertFailedTitle,
                    Lang._Dialogs.SteamConvertFailedSubtitle,
                    Content,
                    Lang._Misc.OkaySad,
                    null,
                    null
            );

        public static async Task<ContentDialogResult> Dialog_GameInstallationFileCorrupt(UIElement Content, string sourceHash, string downloadedHash) =>
            await SpawnDialog(
                    Lang._Dialogs.InstallDataCorruptTitle,
                    string.Format(Lang._Dialogs.InstallDataCorruptSubtitle, sourceHash, downloadedHash),
                    Content,
                    Lang._Misc.NoCancel,
                    Lang._Misc.YesRedownload,
                    null
            );

        public static async Task<ContentDialogResult> Dialog_LocateFirstSetupFolder(UIElement Content, string defaultAppFolder) =>
            await SpawnDialog(
                    Lang._StartupPage.ChooseFolderDialogTitle,
                    string.Format(Lang._StartupPage.ChooseFolderDialogSubtitle, defaultAppFolder),
                    Content,
                    Lang._StartupPage.ChooseFolderDialogCancel,
                    Lang._StartupPage.ChooseFolderDialogPrimary,
                    Lang._StartupPage.ChooseFolderDialogSecondary
            );

        public static async Task<ContentDialogResult> Dialog_ExistingDownload(UIElement Content, long partialLength, long contentLength) =>
            await SpawnDialog(
                    Lang._Dialogs.InstallDataDownloadResumeTitle,
                    string.Format(Lang._Dialogs.InstallDataDownloadResumeSubtitle,
                                  SummarizeSizeSimple(partialLength),
                                  SummarizeSizeSimple(contentLength)),
                    Content,
                    null,
                    Lang._Misc.YesResume,
                    Lang._Misc.NoStartFromBeginning
                );

        public static async Task<ContentDialogResult> Dialog_InsufficientDriveSpace(UIElement Content, long DriveFreeSpace, long RequiredSpace, string DriveLetter) =>
            await SpawnDialog(
                    Lang._Dialogs.InsufficientDiskTitle,
                    string.Format(Lang._Dialogs.InsufficientDiskSubtitle,
                                  SummarizeSizeSimple(DriveFreeSpace),
                                  SummarizeSizeSimple(RequiredSpace),
                                  DriveLetter),
                    Content,
                    null,
                    Lang._Misc.Okay,
                    null
                );

        public static async Task<ContentDialogResult> Dialog_RelocateFolder(UIElement Content) =>
            await SpawnDialog(
                    Lang._Dialogs.RelocateFolderTitle,
                    string.Format(Lang._Dialogs.RelocateFolderSubtitle,
                                  GetAppConfigValue("GameFolder").ToString()),
                    Content,
                    null,
                    Lang._Misc.YesRelocate,
                    Lang._Misc.Cancel
                );

        public static async Task<ContentDialogResult> Dialog_UninstallGame(UIElement Content, string gameLocation, string region) =>
            await SpawnDialog(
                    string.Format(Lang._Dialogs.UninstallGameTitle, region),
                    string.Format(Lang._Dialogs.UninstallGameSubtitle,
                                  gameLocation),
                    Content,
                    null,
                    Lang._Misc.Uninstall,
                    Lang._Misc.Cancel
                );

        public static async Task<ContentDialogResult> Dialog_NeedInstallMediaPackage(UIElement Content) =>
            await SpawnDialog(
                    Lang._Dialogs.NeedInstallMediaPackTitle,
                    Lang._Dialogs.NeedInstallMediaPackSubtitle1 + Lang._Dialogs.NeedInstallMediaPackSubtitle2,
                    Content,
                    Lang._Misc.Cancel,
                    Lang._Misc.Install,
                    Lang._Misc.Skip
                );

        public static async Task<ContentDialogResult> Dialog_InstallMediaPackageFinished(UIElement Content) =>
            await SpawnDialog(
                    Lang._Dialogs.InstallMediaPackCompleteTitle,
                    Lang._Dialogs.InstallMediaPackCompleteSubtitle,
                    Content,
                    null,
                    Lang._Misc.OkayBackToMenu,
                    null
                );

        #region ShowKeybinds
        private static StackPanel GenerateShortcutBlock(string[] kbkeys, string description, string example = null)
        {
            StackPanel Shortcut = new StackPanel() { Margin = new Thickness(0, 4, 0, 4), Orientation = Orientation.Horizontal, VerticalAlignment = VerticalAlignment.Center };
            string colorSchm = Application.Current.RequestedTheme == ApplicationTheme.Dark ? "SystemAccentColorLight2" : "SystemAccentColorDark2";

            foreach (string im in kbkeys)
            {

                Border keyboxborder = new Border()
                {
                    Height = 42, Width = 42,
                    Margin = new Thickness(5, 5, 5, 0),
                    CornerRadius = new CornerRadius(5),
                    Background = new SolidColorBrush((Windows.UI.Color)Application.Current.Resources[colorSchm])
                };
                ThemeShadow ts = new ThemeShadow();
                ts.Receivers.Add(keyboxborder);
                keyboxborder.Translation += Shadow48;
                keyboxborder.Shadow = ts;

                TextBlock keybox = new TextBlock()
                {
                    Text = im,
                    FontWeight = FontWeights.Bold,
                    TextAlignment = TextAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    Foreground = (Brush)Application.Current.Resources["DialogAcrylicBrush"]
                };


                keyboxborder.Child = keybox;
                Shortcut.Children.Add(keyboxborder);
                Shortcut.Children.Add(new TextBlock() { Text = "+", FontWeight = FontWeights.Bold, FontSize = 20, VerticalAlignment = VerticalAlignment.Center });
            }

            Shortcut.Children.RemoveAt(Shortcut.Children.Count - 1);

            if (example != null)
            {
                StackPanel ShortcutDesc = new StackPanel() { Margin = new Thickness(5, 1, 0, 1), Orientation = Orientation.Vertical, VerticalAlignment = VerticalAlignment.Center };
                ShortcutDesc.Children.Add(new TextBlock() { Text = description, FontSize = 14, Margin = new Thickness(0, 2, 0, 1) });
                ShortcutDesc.Children.Add(new TextBlock() { Text = example, FontSize = 11, Margin = new Thickness(0, 1, 0, 2) });
                Shortcut.Children.Add(ShortcutDesc);
            }
            else
            {
                Shortcut.Children.Add(new TextBlock() { Margin = new Thickness(5, 1, 0, 1), Text = description, FontSize = 14, VerticalAlignment = VerticalAlignment.Center });
            }

            return Shortcut;
        }

        public static async Task<ContentDialogResult> Dialog_ShowKeybinds(UIElement Content)
        {
            StackPanel stack = new StackPanel() { Orientation = Orientation.Vertical, MaxWidth = 500 };

            stack.Children.Add(new TextBlock { Text = "General", FontSize = 16, FontWeight = FontWeights.Bold, Margin = new Thickness(0, 8, 0, 8) });
            stack.Children.Add(GenerateShortcutBlock(new string[] { "Ctrl", "Tab" }, "Open this list"));
            stack.Children.Add(GenerateShortcutBlock(new string[] { "Ctrl", "H" }, "Go to the Home page"));

            stack.Children.Add(new TextBlock { Text = "Quick Game/Region change", FontSize = 16, FontWeight = FontWeights.Bold, Margin = new Thickness(0, 16, 0, 2) });
            stack.Children.Add(new TextBlock { Text = "Note: Num corresponds to a numbered key", FontSize = 11.5, Margin = new Thickness(0, 0, 0, 8) });
            stack.Children.Add(GenerateShortcutBlock(new string[] { "Ctrl", "Num" }, "Change game", "E.g. CTRL+1 leads Honkai Impact 3rd's page (last used region)"));
            stack.Children.Add(GenerateShortcutBlock(new string[] { "Shift", "Num" }, "Change region", "E.g. For Genshin Impact, SHIFT+1 leads to the Global region"));

            return await SpawnDialog(
                    "Keyboard Shortcuts",
                    stack,
                    Content,
                    Lang._Misc.Close,
                    null,
                    null,
                    ContentDialogButton.Primary
                );
        }
        #endregion

        public static async Task<ContentDialogResult> SpawnDialog(
            string title, object content, UIElement Content,
            string closeText = null, string primaryText = null,
            string secondaryText = null, ContentDialogButton defaultButton = ContentDialogButton.Primary) =>
            await new ContentDialog
            {
                Title = title,
                Content = content,
                CloseButtonText = closeText,
                PrimaryButtonText = primaryText,
                SecondaryButtonText = secondaryText,
                DefaultButton = defaultButton,
                Background = (Brush)Application.Current.Resources["DialogAcrylicBrush"],
                XamlRoot = Content.XamlRoot
            }.ShowAsync();
    }
}
