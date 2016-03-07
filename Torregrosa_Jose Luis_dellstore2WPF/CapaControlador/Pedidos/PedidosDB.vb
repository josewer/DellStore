Option Strict On
Option Explicit On
Imports System.Collections.ObjectModel
Imports Orders 'esto es capa modelo

Public Class PedidosDB

    Private Pedido As ObservableCollection(Of Orders.Orders)
    Private orderline As Integer
    Private ListaLinesOrder As ObservableCollection(Of OrderLines)


    Public Sub New(Fecha As Date,
                    Id_Cliente As Integer, BaseImponible As Double,
                    Impuesto As Double, Total As Double)

        Pedido = New ObservableCollection(Of Orders.Orders)
        Pedido.Add(New Orders.Orders(Fecha, Id_Cliente, BaseImponible, Impuesto, Total))
        ListaLinesOrder = Pedido(0).GetListaOrderLines

        orderline = 1
    End Sub

    Public Sub New(IdPedido As Integer)
        Pedido = New ObservableCollection(Of Orders.Orders)
        Pedido.Add(New Orders.Orders(IdPedido))
        ListaLinesOrder = Pedido(0).GetListaOrderLines

        Dim maxIDLinea As Integer = 0

        For i As Integer = 0 To ListaLinesOrder.Count - 1 Step 1
            If maxIDLinea < ListaLinesOrder(i).OrderLineId Then
                maxIDLinea = ListaLinesOrder(i).OrderLineId
            End If
        Next

        orderline = (maxIDLinea + 1)

        ActualizarPedido()
    End Sub

    Public Sub BorrarPedido()
        Pedido(0).Borrar()
    End Sub

    Public Sub AddOrderLine(id_producto As Integer, Cantidad As Short)

        Pedido(0).AddOrderLine(id_producto, Cantidad, orderline)
        orderline += 1
        ActualizarPedido()
    End Sub

    Public Sub ActualizarPedido()

        Dim BaseImponible As Double = 0
        Dim Impuesto As Double = 8.25

        Dim NumeroLineas As Integer = Pedido(0).GetListaOrderLines.Count

        For i As Integer = 0 To NumeroLineas - 1 Step 1
            BaseImponible = BaseImponible + Pedido(0).GetListaOrderLines(i).PrecioTotal
        Next

        Dim TotalImpuestos As Double = (BaseImponible * Impuesto) / 100
        Dim ImporteBruto As Double = BaseImponible + TotalImpuestos

        Pedido(0).ActualizarPedido(BaseImponible, TotalImpuestos, ImporteBruto)
        Pedido(0).Actualizar()

    End Sub

    Public Sub BorrarLinea(ByRef lineaPedido As OrderLines)
        Try
            Pedido(0).BorrarLineaPedido(lineaPedido)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

        ActualizarPedido()

    End Sub


    Public Sub ModificarLinea(ByRef lineaPedido As OrderLines, Cantidad As Short)

        Try
            Pedido(0).ModificarLineaPedido(lineaPedido, Cantidad)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

        ActualizarPedido()

    End Sub

    Public Function GetListaLinesOrdes() As ObservableCollection(Of OrderLines)
        Return ListaLinesOrder
    End Function

    Public Function GetPedido() As ObservableCollection(Of Orders.Orders)
        Return Pedido
    End Function


End Class

