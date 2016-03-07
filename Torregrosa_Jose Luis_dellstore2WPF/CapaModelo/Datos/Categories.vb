Option Explicit On
Option Strict On


Public Class Categories

    Private _Category As Integer ' no null
    Public Property Category() As Integer
        Get
            Return _Category
        End Get
        Set(ByVal value As Integer)

            If value <> Nothing Then
                _Category = value
            Else
                Throw New Exception("Category no puede ser nulo")
            End If
        End Set
    End Property


    Private _CategoryName As String ' varying(50) Not NULL
    Public Property CategoryName() As String
        Get
            Return _CategoryName
        End Get
        Set(ByVal value As String)
            If value Is Nothing Then
                Throw New Exception("CategoryName no puede ser nulo")
            ElseIf value.Length > 50 Then
                Throw New Exception("CategoryName  no puede tener más de 50 cáracteres")
            Else
                _CategoryName = value
            End If

        End Set
    End Property


    Public Sub New(category As Integer, categoryName As String)
        Me.Category = category
        Me.CategoryName = categoryName

    End Sub


    Public Sub New(ByVal categories As Categories)
        Me.Category = categories.Category
        Me.CategoryName = categories.CategoryName
    End Sub


    Public Sub New()
        Me.Category = -1
        Me.CategoryName = "Default"
    End Sub

    Public Sub Dispose()
        _Category = Nothing
        _CategoryName = Nothing
    End Sub


    Protected Overrides Sub Finalize()
        _Category = Nothing
        _CategoryName = Nothing
    End Sub

    Public Overrides Function ToString() As String
        Return "Category -> " & Category & ", CategoryName - > " &
            CategoryName
    End Function



    ''' <summary>
    ''' Constructor que recibe la id de una categoria y consulta en la base de datos para
    ''' obtener el resto de campos sobre esta tabla.
    ''' </summary>

    Private _ADO As CategoriesADO

    Public Sub New(ByVal CategoryID As Integer)

        _ADO = New CategoriesADO

        Dim Category As Categories

        Dim Sql As String = String.Format("SELECT CATEGORYNAME FROM CATEGORIES 
                                WHERE CATEGORY = {0}", CategoryID)

        Category = _ADO.Obtener(Sql)

        If (Category Is Nothing) Then
            Throw New Exception("Se ha producido un error al obtener la categoría.")
        Else
            Me.Category = CategoryID
            Me.CategoryName = Category.CategoryName
        End If

    End Sub


End Class

