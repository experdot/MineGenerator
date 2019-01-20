Imports System.Windows.Media.Animation
Imports Nukepayload2.UI.Win32
Imports MineGenerator.Models
Imports MineGenerator.Views
Imports MineGenerator.Services

Class MainWindow
    Dim selectedIndexes As New Stack(Of Integer)
    Dim suppressAutoNavigate As Boolean

    Private Sub Rectangle_PreviewMouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs)
        DragMove()
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As RoutedEventArgs)
        Close()
    End Sub

    Dim ScaleAnimRev As New DoubleAnimation(1.03, 1, TimeSpan.FromMilliseconds(120))
    Dim ScaleAnim As New DoubleAnimation(0.93, 1, TimeSpan.FromMilliseconds(120))
    Dim RenderScale As New ScaleTransform

    Private Sub LstLeftBar_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles LstLeftBar.SelectionChanged
        If LstLeftBar.SelectedItem IsNot Nothing AndAlso Not suppressAutoNavigate Then
            Dim sel = DirectCast(LstLeftBar.SelectedItem, LeftBarModel)
            Dim assocPage = sel.AssocPage
            Navigate(assocPage)
        End If
    End Sub

    Private Sub Navigate(assocPage As Page)
        RenderScale.BeginAnimation(ScaleTransform.ScaleXProperty, ScaleAnim)
        RenderScale.BeginAnimation(ScaleTransform.ScaleYProperty, ScaleAnim)
        MainFrame.Navigate(assocPage)
    End Sub

    Private Sub BtnToggleWidth_Click(sender As Object, e As RoutedEventArgs) Handles BtnToggleWidth.Click
        If GrdSplit.ColumnDefinitions(0).ActualWidth <> 48 Then
            GrdSplit.ColumnDefinitions(0).Width = New GridLength(48)
        Else
            GrdSplit.ColumnDefinitions(0).Width = New GridLength(1, GridUnitType.Auto)
        End If
    End Sub

    Private Sub MainWindow_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        LstLeftBar.SelectedIndex = 0
        MainFrame.RenderTransform = RenderScale
        AttachNavigationService(MainFrame)
    End Sub

    Private Sub Backward(sender As Object, e As RoutedEventArgs)
        If MainFrame.CanGoBack Then
            RenderScale.BeginAnimation(ScaleTransform.ScaleXProperty, ScaleAnimRev)
            RenderScale.BeginAnimation(ScaleTransform.ScaleYProperty, ScaleAnimRev)
            MainFrame.GoBack()
        End If
    End Sub

    Private Sub BtnSetting_Click(sender As Object, e As RoutedEventArgs)
        If LstLeftBar.SelectedIndex = -1 Then
            Return
        End If
        Navigate(SettingsPage.Current)
        LstLeftBar.SelectedIndex = -1
    End Sub

    Private Sub MainWindow_SourceInitialized(sender As Object, e As EventArgs) Handles Me.SourceInitialized
        Dim windowCompositionFactory As New WindowCompositionFactory
        If Win32ApiInformation.IsWindowAcrylicApiPresent OrElse Win32ApiInformation.IsAeroGlassApiPresent Then
            ' Enable blur effect
            Dim composition = windowCompositionFactory.TryCreateForCurrentView
            If composition?.TrySetBlur(Me, True) Then
                ClientArea.Background = New SolidColorBrush(Color.FromArgb(&HCC, &HFF, &HFF, &HFF))
                Background = Brushes.Transparent
            End If
        End If
        If Win32ApiInformation.IsProcessDpiAwarenessApiPresent Then
            ' Enable DPI awareness
            DpiAwareness = ProcessDpiAwareness.PerMonitorDpiAware
        End If
    End Sub

    Private Sub MainFrame_Navigating(sender As Object, e As NavigatingCancelEventArgs) Handles MainFrame.Navigating
        rectSettingSelected.Visibility = If(TypeOf e.Content Is SettingsPage, Visibility.Visible, Visibility.Collapsed)
        If e.NavigationMode = NavigationMode.New Then
            selectedIndexes.Push(LstLeftBar.SelectedIndex)
        Else
            suppressAutoNavigate = True
            If selectedIndexes.Count > 0 Then
                selectedIndexes.Pop()
                LstLeftBar.SelectedIndex = If(TypeOf e.Content Is SettingsPage, -1, selectedIndexes.Peek)
            End If
            suppressAutoNavigate = False
        End If
    End Sub
End Class