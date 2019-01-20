Imports System.Windows.Controls.Primitives

Namespace Controls
    Public Class ToggleSwitch
        Inherits ToggleButton

        Shared Sub New()
            ' themes\generic.xaml
            DefaultStyleKeyProperty.OverrideMetadata(GetType(ToggleSwitch), New FrameworkPropertyMetadata(GetType(ToggleSwitch)))
        End Sub

    End Class

End Namespace
