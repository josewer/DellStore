﻿#ExternalChecksum("..\..\MainWindow.xaml","{406ea660-64cf-4c82-b6f0-42d48172a799}","EADF2268289DE82B0DE264C1645E0550")
'------------------------------------------------------------------------------
' <auto-generated>
'     Este código fue generado por una herramienta.
'     Versión de runtime:4.0.30319.42000
'
'     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
'     se vuelve a generar el código.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports CapaPresentacion
Imports System
Imports System.Diagnostics
Imports System.Windows
Imports System.Windows.Automation
Imports System.Windows.Controls
Imports System.Windows.Controls.Primitives
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Ink
Imports System.Windows.Input
Imports System.Windows.Markup
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Media.Effects
Imports System.Windows.Media.Imaging
Imports System.Windows.Media.Media3D
Imports System.Windows.Media.TextFormatting
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports System.Windows.Shell


'''<summary>
'''MainWindow
'''</summary>
<Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>  _
Partial Public Class MainWindow
    Inherits System.Windows.Window
    Implements System.Windows.Markup.IComponentConnector
    
    
    #ExternalSource("..\..\MainWindow.xaml",14)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents Menu As System.Windows.Controls.Menu
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\MainWindow.xaml",37)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents BarraEstado As System.Windows.Controls.Primitives.StatusBar
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\MainWindow.xaml",39)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents TextBarraEstado As System.Windows.Controls.TextBlock
    
    #End ExternalSource
    
    Private _contentLoaded As Boolean
    
    '''<summary>
    '''InitializeComponent
    '''</summary>
    <System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")>  _
    Public Sub InitializeComponent() Implements System.Windows.Markup.IComponentConnector.InitializeComponent
        If _contentLoaded Then
            Return
        End If
        _contentLoaded = true
        Dim resourceLocater As System.Uri = New System.Uri("/CapaPresentacion;component/mainwindow.xaml", System.UriKind.Relative)
        
        #ExternalSource("..\..\MainWindow.xaml",1)
        System.Windows.Application.LoadComponent(Me, resourceLocater)
        
        #End ExternalSource
    End Sub
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0"),  _
     System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never),  _
     System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes"),  _
     System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity"),  _
     System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")>  _
    Sub System_Windows_Markup_IComponentConnector_Connect(ByVal connectionId As Integer, ByVal target As Object) Implements System.Windows.Markup.IComponentConnector.Connect
        If (connectionId = 1) Then
            
            #ExternalSource("..\..\MainWindow.xaml",2)
            AddHandler CType(target,MainWindow).Closing, New System.ComponentModel.CancelEventHandler(AddressOf Me.Form1_FormClosing)
            
            #End ExternalSource
            Return
        End If
        If (connectionId = 2) Then
            Me.Menu = CType(target,System.Windows.Controls.Menu)
            Return
        End If
        If (connectionId = 3) Then
            
            #ExternalSource("..\..\MainWindow.xaml",19)
            AddHandler CType(target,System.Windows.Controls.MenuItem).Click, New System.Windows.RoutedEventHandler(AddressOf Me.AbrirCliente)
            
            #End ExternalSource
            Return
        End If
        If (connectionId = 4) Then
            
            #ExternalSource("..\..\MainWindow.xaml",20)
            AddHandler CType(target,System.Windows.Controls.MenuItem).Click, New System.Windows.RoutedEventHandler(AddressOf Me.ModificarCliente)
            
            #End ExternalSource
            Return
        End If
        If (connectionId = 5) Then
            
            #ExternalSource("..\..\MainWindow.xaml",26)
            AddHandler CType(target,System.Windows.Controls.MenuItem).Click, New System.Windows.RoutedEventHandler(AddressOf Me.AltaProducto)
            
            #End ExternalSource
            Return
        End If
        If (connectionId = 6) Then
            
            #ExternalSource("..\..\MainWindow.xaml",27)
            AddHandler CType(target,System.Windows.Controls.MenuItem).Click, New System.Windows.RoutedEventHandler(AddressOf Me.ModificarProducto)
            
            #End ExternalSource
            Return
        End If
        If (connectionId = 7) Then
            
            #ExternalSource("..\..\MainWindow.xaml",33)
            AddHandler CType(target,System.Windows.Controls.MenuItem).Click, New System.Windows.RoutedEventHandler(AddressOf Me.AltaPedido)
            
            #End ExternalSource
            Return
        End If
        If (connectionId = 8) Then
            
            #ExternalSource("..\..\MainWindow.xaml",34)
            AddHandler CType(target,System.Windows.Controls.MenuItem).Click, New System.Windows.RoutedEventHandler(AddressOf Me.ModificarPedido)
            
            #End ExternalSource
            Return
        End If
        If (connectionId = 9) Then
            Me.BarraEstado = CType(target,System.Windows.Controls.Primitives.StatusBar)
            Return
        End If
        If (connectionId = 10) Then
            Me.TextBarraEstado = CType(target,System.Windows.Controls.TextBlock)
            Return
        End If
        Me._contentLoaded = true
    End Sub
End Class

