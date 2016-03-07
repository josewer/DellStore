Option Explicit On
Option Strict On
Imports System.Collections.ObjectModel
Imports System.ComponentModel

Public Class Orders
    Implements INotifyPropertyChanged

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Protected Sub OnPropertyChanged(ByVal name As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(name))
    End Sub

    Private _OrderId As Integer ' not null
    Public Property OrderId() As Integer
        Get
            Return _OrderId
        End Get
        Set(ByVal value As Integer)
            If value = Nothing Then
                Throw New Exception("OrderId no puede ser nulo")
            Else
                _OrderId = value
            End If
        End Set
    End Property


    Private _OrderDate As Date ' date Not NULL,
    Public Property OrderDate() As Date
        Get
            Return _OrderDate
        End Get
        Set(ByVal value As Date)
            If value = Nothing Then
                Throw New Exception("OrderDate no puede ser nulo")
            Else
                _OrderDate = value
            End If
        End Set
    End Property


    Private _CustomerId As Integer
    Public Property CustomerId() As Integer
        Get
            Return _CustomerId
        End Get
        Set(ByVal value As Integer)
            If IsNumeric(value) Then
                _CustomerId = value
            Else
                Throw New Exception("CustomerId tiene que ser númerico.")
            End If
        End Set
    End Property


    Private _NetAmount As Double '  Not NULL, numeric(12, 2) 
    Public Property NetAmount() As Double
        Get
            Return _NetAmount
        End Get
        Set(ByVal value As Double)
            If value = 0 Or value <> Nothing Then
                _NetAmount = CDbl(FormatNumber(value, 2))
                OnPropertyChanged("NetAmount")
            Else
                Throw New Exception("NetAmount no puede ser nulo")
            End If
        End Set
    End Property


    Private _Tax As Double '  Not NULL, numeric(12, 2) 
    Public Property Tax() As Double
        Get
            Return _Tax
        End Get
        Set(ByVal value As Double)
            If value = 0 Or value <> Nothing Then
                _Tax = CDbl(FormatNumber(value, 2))
                OnPropertyChanged("Tax")
            Else
                Throw New Exception("Tax no puede ser nulo")
            End If
        End Set
    End Property


    Private _TotalAmount As Double '  Not NULL, numeric(12, 2) 

    Public Property TotalAmount() As Double
        Get
            Return _TotalAmount
        End Get
        Set(ByVal value As Double)
            If value = 0 Or value <> Nothing Then
                _TotalAmount = CDbl(FormatNumber(value, 2))
                OnPropertyChanged("TotalAmount")
            Else
                Throw New Exception("TotalAmount no puede ser nulo")
            End If
        End Set
    End Property

    Private ReadOnly _Impuesto As String = "8.25%"
    Public ReadOnly Property Impuesto() As String
        Get
            Return _Impuesto
        End Get
    End Property


    Public Sub New(orderId As Integer, orderDate As Date,
                    customerId As Integer, netAmount As Double,
                    tax As Double, totalAmount As Double)
        Me.OrderId = orderId
        Me.OrderDate = orderDate
        Me.CustomerId = customerId
        Me.NetAmount = netAmount
        Me.Tax = tax
        Me.TotalAmount = totalAmount
        _ADO = New OrdersADO
    End Sub

    Public Sub New(ByVal Order As Orders)
        Me.OrderId = Order.OrderId
        Me.OrderDate = Order.OrderDate
        Me.CustomerId = Order.CustomerId
        Me.NetAmount = Order.NetAmount
        Me.Tax = Order.Tax
        Me.TotalAmount = Order.TotalAmount
        _ADO = New OrdersADO
    End Sub

    Public Sub New()
        Me.OrderId = -1
        Me.OrderDate = #1/1/1900#
        Me.CustomerId = -1
        Me.NetAmount = -1
        Me.Tax = -1
        Me.TotalAmount = -1
        _ADO = New OrdersADO
    End Sub


    Public Sub Dispose()
        _OrderId = Nothing
        _OrderDate = Nothing
        _CustomerId = Nothing
        _NetAmount = Nothing
        _Tax = Nothing
        _TotalAmount = Nothing
        _ADO.Dispose()
    End Sub

    Protected Overrides Sub Finalize()
        _OrderId = Nothing
        _OrderDate = Nothing
        _CustomerId = Nothing
        _NetAmount = Nothing
        _Tax = Nothing
        _TotalAmount = Nothing
        _ADO.Dispose()
    End Sub

    Public Overrides Function ToString() As String
        Return "OrderId -> " & OrderId & ", OrderDate - > " &
            OrderDate & ", CustomerId - > " & CustomerId
    End Function


    ''' <summary>
    ''' Me creo una lista de lineas de pedido para cada pedido
    ''' </summary>

    Private ListaOrderLines As ObservableCollection(Of OrderLines)

    Public Function GetListaOrderLines() As ObservableCollection(Of OrderLines)
        Return ListaOrderLines
    End Function


    Public Sub ModificarLineaPedido(ByRef lineaPedido As OrderLines, cantidad As Short)
        ListaOrderLines(ListaOrderLines.IndexOf(lineaPedido)).Quantity = cantidad
        ListaOrderLines(ListaOrderLines.IndexOf(lineaPedido)).ActualizarPrecio()
    End Sub

    Public Sub BorrarLineaPedido(ByRef lineaPedido As OrderLines)
        lineaPedido.Borrar()
        ListaOrderLines.Remove(lineaPedido)
    End Sub

    ''' <summary>
    ''' Funcion que añade una linea de pedido a la lista, pero antes 
    ''' compruba si ese producto esta ya insertado, en ese caso suma la cantidad.
    ''' </summary>

    Public Sub AddOrderLine(prod_Id As Integer, quantity As Short,
                            orderline As Integer)

        Dim Encontrado As Boolean = False

        For i As Integer = 0 To ListaOrderLines.Count - 1 Step 1

            Dim Id = ListaOrderLines(i).Prod_Id

            If Id = prod_Id Then

                ListaOrderLines(i).Quantity =
                    ListaOrderLines(i).Quantity + quantity

                ListaOrderLines(i).ActualizarPrecio()

                Encontrado = True

            End If
        Next

        If Encontrado = False Then
            ListaOrderLines.Add(New OrderLines(OrderId, prod_Id, quantity, OrderDate, orderline))
        End If
    End Sub

    Public Sub ActualizarPedido(netAmount As Double,
                    tax As Double, totalAmount As Double)

        Me.NetAmount = netAmount
        Me.Tax = tax
        Me.TotalAmount = totalAmount
    End Sub




    ''''''''''''''''''''''''''''''''''''''''''''''''
    ' AQUI EMPIEZAN LAS ACCIONES CON LA BASE DE DATOS.
    ''''''''''''''''''''''''''''''''''''''''''''''''
    ''' <summary>
    ''' Constructor para insertar un pedido en la base de datos.
    ''' </summary>

    Private _ADO As OrdersADO

    Public Sub New(orderDate As Date,
                    customerId As Integer, netAmount As Double,
                    tax As Double, totalAmount As Double)


        _ADO = New OrdersADO

        Dim Sql As String = String.Format("INSERT INTO ORDERS 
            ( orderDate, customerId, netAmount, tax, totalAmount) 
            VALUES ('{0}' , '{1}'  , '{2}'  , '{3}'  , '{4}'  ) 
            RETURNING ORDERID",
            orderDate, customerId, netAmount, tax, totalAmount)


        Dim orderId As Integer = _ADO.Insertar(Sql)

        If (orderId = 0) Then
            Throw New Exception("Se ha producido un error al insertar el pedido.")
        Else
            Me.OrderId = orderId
            Me.OrderDate = orderDate
            Me.CustomerId = customerId
            Me.NetAmount = netAmount
            Me.Tax = tax
            Me.TotalAmount = totalAmount
            ListaOrderLines = New ObservableCollection(Of OrderLines)
        End If
    End Sub

    ''' <summary>
    ''' Obtiene un pedido a partir de los datos de la base de datos.
    ''' </summary>


    Public Sub New(orderId As Integer)

        _ADO = New OrdersADO

        Dim Sql As String = String.Format("SELECT
            orderId , orderDate, customerId, netAmount, tax, totalAmount 
            FROM ORDERS
            WHERE orderId = '{0}';",
            orderId)

        Try
            Dim order = _ADO.Obtener(Sql)

            Me.OrderId = order.OrderId
            Me.OrderDate = order.OrderDate
            Me.CustomerId = order.CustomerId
            Me.NetAmount = order.NetAmount
            Me.Tax = order.Tax
            Me.TotalAmount = order.TotalAmount

            ListaOrderLines = New ObservableCollection(Of OrderLines)(New OrderlinesADO().Obtener(orderId))

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Sub


    ''' <summary>
    ''' BORRAR EL PEDIDO ACTUAL DE LA BASE DE DATOS
    ''' </summary>
    Public Sub Borrar()

        ' borro todas sus lineas primero
        For i As Integer = 0 To ListaOrderLines.Count - 1 Step 1
            ListaOrderLines(i).Borrar()
        Next

        Dim sql As String = String.Format("DELETE FROM ORDERS 
                                            WHERE ORDERID = '{0}'", OrderId)

        Dim Borrado As Boolean = _ADO.Borrar(sql)

        If (Borrado = False) Then
            Throw New Exception("Se ha producido un error al borrar el pedido.")
        End If

    End Sub


    ''' <summary>
    ''' ACTUALIZA EL PEDIDO ACTUAL DE LA BASE DE DATOS
    ''' </summary>
    Public Sub Actualizar()

        Dim Sql As String = String.Format("UPDATE  ORDERS SET
            OrderDate = '{0}' , CustomerId = '{1}', NetAmount = '{2}' , Tax  = '{3}' , 
            TotalAmount = '{4}' 
            WHERE ORDERID = '{5}' ",
            OrderDate, CustomerId, NetAmount.ToString.Replace(",", "."),
                                          Tax.ToString.Replace(",", "."),
                                          TotalAmount.ToString.Replace(",", "."),
                                          OrderId)

        Dim Actualizado As Boolean = _ADO.Actualizar(Sql)

        If (Actualizado = False) Then
            Throw New Exception("Se ha producido un error al actualizar el pedido.")
        End If

    End Sub


End Class

