Imports MineGenerator.Loader

Namespace Models
    Public Class BlockManager
        Public Property RawBitmapSource As BitmapSource

        Public Sub LoadBlocks()
            Dim loader = New BitmapLoader(ConvertBitmapSourceToBitmap(RawBitmapSource))
            Dim blocks = loader.Load()
            Debug.WriteLine(blocks.Count)
        End Sub

        Private Function ConvertBitmapSourceToBitmap(source As BitmapSource) As System.Drawing.Bitmap
            Using ms As System.IO.MemoryStream = New System.IO.MemoryStream()
                Dim encoder As BitmapEncoder = New BmpBitmapEncoder()
                encoder.Frames.Add(BitmapFrame.Create(source))
                encoder.Save(ms)
                Return New System.Drawing.Bitmap(ms)
            End Using
        End Function
    End Class
End Namespace

