Option Explicit On
Option Strict On

Public Class Products

    Private _Prod_Id As Integer '  Not NULL,
    Public Property Prod_Id() As Integer
        Get
            Return _Prod_Id
        End Get
        Set(ByVal value As Integer)
            If value <> Nothing Then
                _Prod_Id = value
            Else
                Throw New Exception("Prod_Id no puede ser nulo")
            End If
        End Set
    End Property


    Private _Category As Integer '  Not NULL,
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


    Private _Title As String ' varying(50) Not NULL,
    Public Property Title() As String
        Get
            Return _Title
        End Get
        Set(ByVal value As String)
            If value Is Nothing Then
                Throw New Exception("Title no puede ser nulo.")
            ElseIf value.Length > 50 Then
                Throw New Exception("Title no puede tener más de 50 cáracteres.")
            Else
                _Title = value
            End If
        End Set
    End Property

    Private _Actor As String ' varying(50) Not NULL,
    Public Property Actor() As String
        Get
            Return _Actor
        End Get
        Set(ByVal value As String)
            If value Is Nothing Then
                Throw New Exception("Actor no puede ser nulo.")
            ElseIf value.Length > 50 Then
                Throw New Exception("Actor no puede tener más de 50 cáracteres.")
            Else
                _Actor = value
            End If
        End Set
    End Property


    Private _Common_Prod_Id As Integer '  Not NULL,
    Public Property Common_Prod_Id() As Integer
        Get
            Return _Common_Prod_Id
        End Get
        Set(ByVal value As Integer)
            If value <> Nothing Then
                _Common_Prod_Id = value
            Else
                Throw New Exception("Common_Prod_Id no puede ser nulo")
            End If
        End Set
    End Property


    Private _Special As Short
    Public Property Special() As Short
        Get
            Return _Special
        End Get
        Set(ByVal value As Short)
            _Special = value
        End Set
    End Property


    Private _Price As Double '  Not NULL, numeric(12, 2) 
    Public Property Price() As Double
        Get
            Return _Price
        End Get
        Set(ByVal value As Double)
            If value = 0 Or value <> Nothing Then
                _Price = CDbl(FormatNumber(value, 2))
            Else
                Throw New Exception("Price no puede ser nulo")
            End If
        End Set
    End Property


    Public Sub New(prod_Id As Integer, category As Integer, title As String,
                   actor As String, common_Prod_Id As Integer, special As Short,
                   price As Double)
        Me.Prod_Id = prod_Id
        Me.Category = category
        Me.Title = title
        Me.Actor = actor
        Me.Common_Prod_Id = common_Prod_Id
        Me.Special = special
        Me.Price = price
        _ADO = New ProductsADO
    End Sub

    Public Sub New(ByVal Product As Products)
        Me.Prod_Id = Product.Prod_Id
        Me.Category = Product.Category
        Me.Title = Product.Title
        Me.Actor = Product.Actor
        Me.Common_Prod_Id = Product.Common_Prod_Id
        Me.Special = Product.Special
        Me.Price = Product.Price
        _ADO = New ProductsADO
    End Sub

    Public Sub New()
        Me.Prod_Id = -1
        Me.Category = -1
        Me.Title = "Default"
        Me.Actor = "Default"
        Me.Common_Prod_Id = -1
        Me.Special = -1
        Me.Price = -1
        _ADO = New ProductsADO
    End Sub

    Public Sub Dispose()
        _Prod_Id = Nothing
        _Category = Nothing
        _Title = Nothing
        _Actor = Nothing
        _Common_Prod_Id = Nothing
        _Special = Nothing
        _Price = Nothing
        _ADO.Dispose()
    End Sub

    Protected Overrides Sub Finalize()
        _Prod_Id = Nothing
        _Category = Nothing
        _Title = Nothing
        _Actor = Nothing
        _Common_Prod_Id = Nothing
        _Special = Nothing
        _Price = Nothing
    End Sub


    Public Overrides Function ToString() As String
        Return "Prod_Id -> " & Prod_Id & ", Category - > " &
            Category & ", Title - > " & Title
    End Function


    ''''''''''''''''''''''''''''''''''''''''''''''''
    ' AQUI EMPIEZAN LAS ACCIONES CON LA BASE DE DATOS.
    ''''''''''''''''''''''''''''''''''''''''''''''''
    ''' <summary>
    ''' Constructor para insertar un producto en la base de datos.
    ''' </summary>

    Private _ADO As ProductsADO

    Public Sub New(category As Integer, title As String,
               actor As String, common_Prod_Id As Integer, special As Short,
               price As Double)


        _ADO = New ProductsADO

        Dim Sql As String = String.Format("INSERT INTO PRODUCTS 
            ( category , title , actor , common_Prod_Id , special , price ) 
            VALUES ('{0}' , '{1}'  , '{2}'  , '{3}'  , '{4}'  , '{5}' ) 
            RETURNING PROD_ID",
            category, title, actor, common_Prod_Id, special, price)


        Dim ProductId As Integer = _ADO.Insertar(Sql)

        If (ProductId = 0) Then
            Throw New Exception("Se ha producido un error al insertar el producto.")
        Else

            Me.Prod_Id = ProductId
            Me.Category = category
            Me.Title = title
            Me.Actor = actor
            Me.Common_Prod_Id = common_Prod_Id
            Me.Special = special
            Me.Price = price

        End If
    End Sub

    ''' <summary>
    ''' Constructor que obtiene un producto a traves de una id.
    ''' </summary>

    Public Sub New(ByVal ProductID As Integer)

        _ADO = New ProductsADO

        Dim Product As Products

        Dim SQL As String = String.Format("SELECT Prod_Id ,category, title, actor, common_Prod_Id, special, price
            FROM PRODUCTS WHERE Prod_Id = '{0}';",
                                          ProductID)

        Product = _ADO.Obtener(SQL)

        If (Product Is Nothing) Then
            Throw New Exception("Se ha producido un error al obtener el producto.")
        Else
            Me.Prod_Id = Product.Prod_Id
            Me.Category = Product.Category
            Me.Title = Product.Title
            Me.Actor = Product.Actor
            Me.Common_Prod_Id = Product.Common_Prod_Id
            Me.Special = Product.Special
            Me.Price = Product.Price
        End If

    End Sub


    ''' <summary>
    ''' BORRAR EL PRODUCTO ACTUAL DE LA BASE DE DATOS
    ''' </summary>
    Public Sub Borrar()

        Dim sql As String = String.Format("DELETE FROM PRODUCTS 
                                            WHERE PROD_ID = '{0}'", Prod_Id)

        Dim Borrado As Boolean = _ADO.Borrar(sql)

        If (Borrado = False) Then
            Throw New Exception("Se ha producido un error al borrar el producto.")
        End If

    End Sub


    ''' <summary>
    ''' ACTUALIZA EL CLIENTE ACTUAL DE LA BASE DE DATOS
    ''' </summary>
    Public Sub Actualizar()

        Dim Sql As String = String.Format("UPDATE  PRODUCTS SET
            category = '{0}' , title = '{1}', actor = '{2}' , common_Prod_Id  = '{3}' , 
            special = '{4}', price = '{5}' 
            WHERE PROD_ID = '{6}' ",
            Category, Title, Actor, Common_Prod_Id, Special, Price, Prod_Id)

        Dim Actualizado As Boolean = _ADO.Actualizar(Sql)

        If (Actualizado = False) Then
            Throw New Exception("Se ha producido un error al actualizar el producto.")
        End If

    End Sub
End Class