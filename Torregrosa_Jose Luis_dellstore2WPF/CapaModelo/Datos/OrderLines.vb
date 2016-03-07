Option Explicit On
Option Strict On
Imports System.ComponentModel

Public Class OrderLines
    Implements INotifyPropertyChanged


    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Protected Sub OnPropertyChanged(ByVal name As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(name))
    End Sub

    Private _OrderLineId As Integer '  Not NULL,
    Public Property OrderLineId() As Integer
        Get
            Return _OrderLineId
        End Get
        Set(ByVal value As Integer)
            If value <> Nothing Then
                _OrderLineId = value
            Else
                Throw New Exception("OrderLineId no puede ser nulo")
            End If
        End Set
    End Property


    Private _OrderId As Integer '  Not NULL,
    Public Property OrderId() As Integer
        Get
            Return _OrderId
        End Get
        Set(ByVal value As Integer)
            If value <> Nothing Then
                _OrderId = value
            Else
                Throw New Exception("OrderId no puede ser nulo.")
            End If
        End Set
    End Property


    Private _Prod_Id As Integer '  Not NULL,
    Public Property Prod_Id() As Integer
        Get
            Return _Prod_Id
        End Get
        Set(ByVal value As Integer)
            If value <> Nothing Then
                _Prod_Id = value
            Else
                Throw New Exception("Prod_Id no puede ser nulo.")
            End If
        End Set
    End Property

    Private _Quantity As Short '  Not NULL,
    Public Property Quantity() As Short
        Get
            Return _Quantity
        End Get
        Set(ByVal value As Short)
            If value = 0 Or value <> Nothing Then
                _Quantity = value
                OnPropertyChanged("Quantity")
            Else
                Throw New Exception("Quantity no puede ser nulo.")
            End If
        End Set
    End Property


    Private _OrderDate As Date '  Not NULL,

    Public Property OrderDate() As Date
        Get
            Return _OrderDate
        End Get
        Set(ByVal value As Date)
            If value <> Nothing Then
                _OrderDate = value
            Else
                Throw New Exception("OrderDate no puede ser nulo.")
            End If
        End Set
    End Property

    Private _Produto As Products
    Public Property Producto() As Products
        Get
            Return _Produto
        End Get
        Set(ByVal value As Products)
            _Produto = value
        End Set
    End Property

    Private _PrecioTotal As Double
    Public Property PrecioTotal() As Double
        Get
            Return _PrecioTotal
        End Get
        Set(ByVal value As Double)
            _PrecioTotal = value
            OnPropertyChanged("PrecioTotal")
        End Set
    End Property


    Public Sub New(orderLineId As Integer, orderId As Integer, prod_Id As Integer,
                   quantity As Short, orderDate As Date)
        Me.OrderLineId = orderLineId
        Me.OrderId = orderId
        Me.Prod_Id = prod_Id
        Me.Quantity = quantity
        Me.OrderDate = orderDate
        Producto = New Products(prod_Id)
        _ADO = New OrderlinesADO
        ActualizarPrecio()
    End Sub

    Public Sub New(ByVal OrderLine As OrderLines)
        Me.OrderLineId = OrderLine.OrderLineId
        Me.OrderId = OrderLine.OrderId
        Me.Prod_Id = OrderLine.Prod_Id
        Me.Quantity = OrderLine.Quantity
        Me.OrderDate = OrderLine.OrderDate
        Me.Producto = OrderLine.Producto
        _ADO = New OrderlinesADO
    End Sub

    Public Sub New()
        Me.OrderLineId = -1
        Me.OrderId = -1
        Me.Prod_Id = -1
        Me.Quantity = -1
        Me.OrderDate = #1/1/1900#
        _ADO = New OrderlinesADO
    End Sub

    Public Sub Dispose()
        _OrderLineId = Nothing
        _OrderId = Nothing
        _Prod_Id = Nothing
        _Quantity = Nothing
        _OrderDate = Nothing
        _ADO.Dispose()
    End Sub

    Protected Overrides Sub Finalize()
        _OrderLineId = Nothing
        _OrderId = Nothing
        _Prod_Id = Nothing
        _Quantity = Nothing
        _OrderDate = Nothing
        _ADO.Dispose()
    End Sub

    Public Overrides Function ToString() As String
        Return "OrderLineId -> " & OrderLineId & ", OrderId - > " &
            OrderId & ", Prod_Id - > " & Prod_Id
    End Function


    Public Sub ActualizarPrecio()

        If (Quantity = 0) Then
            Borrar()
        Else
            PrecioTotal = Quantity * Producto.Price
            Actualizar()
        End If

    End Sub

    ''''''''''''''''''''''''''''''''''''''''''''''''
    ' AQUI EMPIEZAN LAS ACCIONES CON LA BASE DE DATOS.
    ''''''''''''''''''''''''''''''''''''''''''''''''
    ''' <summary>
    ''' Constructor para insertar una linea de pedido en la base de datos.
    ''' </summary>

    Private _ADO As OrderlinesADO

    Public Sub New(orderId As Integer, prod_Id As Integer,
                   quantity As Short, orderDate As Date, orderlineId As Integer)

        _ADO = New OrderlinesADO


        Dim Sql As String = String.Format("INSERT INTO ORDERLINES 
            ( orderId, prod_Id, quantity, orderDate , orderlineId) 
            VALUES ('{0}' , '{1}'  , '{2}'  , '{3}' , '{4}' ) ",
            orderId, prod_Id, quantity, orderDate, orderlineId)


        _ADO.Insertar(Sql)

        Me.OrderLineId = orderlineId
        Me.OrderId = orderId
        Me.Prod_Id = prod_Id
        Me.Quantity = quantity
        Me.OrderDate = orderDate
        Producto = New Products(prod_Id)

        PrecioTotal = Producto.Price * quantity

    End Sub


    ''' <summary>
    ''' BORRAR la linea de pedido ACTUAL DE LA BASE DE DATOS
    ''' </summary>
    Public Sub Borrar()

        Dim sql As String = String.Format("DELETE FROM ORDERLINES 
                                            WHERE orderLineId = '{0}' AND OrderId = '{1}'",
                                          OrderLineId, OrderId)

        Dim Borrado As Boolean = _ADO.Borrar(sql)

        If (Borrado = False) Then
            Throw New Exception("Se ha producido un error al borrar la línea de pedido.")
        End If

    End Sub


    ''' <summary>
    ''' ACTUALIZA LA LINEA DE PEDIDO ACTUAL DE LA BASE DE DATOS
    ''' </summary>
    Public Sub Actualizar()

        Dim Sql As String = String.Format("UPDATE  ORDERLINES SET 
            OrderId = '{0}' , Prod_Id = '{1}', Quantity = '{2}' , OrderDate  = '{3}' 
            WHERE orderLineId = '{4}' AND OrderId = '{5}'",
            OrderId, Prod_Id, Quantity, OrderDate, OrderLineId, OrderId)

        Dim Actualizado As Boolean = _ADO.Actualizar(Sql)

        If (Actualizado = False) Then
            Throw New Exception("Se ha producido un error al actualizar la línea de pedido.")
        End If

    End Sub

End Class