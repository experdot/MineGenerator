Imports System.ComponentModel
Imports System.Collections.ObjectModel
Imports System.Windows.Input
Imports MineGenerator.Models
Imports MineGenerator.Commands

Namespace ViewModels

    Public Class MainViewModel
        Inherits ViewModelBase(Of MainViewModel)

        Public Property PreviewImage As BitmapSource
            Get
                Return BlockManager.RawBitmapSource
            End Get
            Set(value As BitmapSource)
                If Not value.Equals(BlockManager.RawBitmapSource) Then
                    BlockManager.RawBitmapSource = value
                    OnPropertyChanged()
                End If
            End Set
        End Property

        Public ReadOnly Property ImportCommand As New ImportCommand

        Public ReadOnly BlockManager As New BlockManager

        Public Sub New()
            AddHandler ImportCommand.BitmapSourceChanged, AddressOf OnBitmapSourceChanged
        End Sub

        Public Sub OnBitmapSourceChanged(sender As Object, bitmapSource As BitmapSource)
            PreviewImage = bitmapSource
            BlockManager.LoadBlocks()
        End Sub
    End Class

End Namespace