Option Explicit On
Option Strict On

Imports Npgsql


Public Class BdPostgre
    Private _ConexionConBD As NpgsqlConnection
    Private _Orden As NpgsqlCommand
    Private _Lector As NpgsqlDataReader
    Shared _strConexion As String

    Public Sub New()
        _strConexion = String.Format("Server={0};Port={1};User Id={2};Password={3};Database={4};",
                                    "localhost", "5432", "dellstore2", "dellstore2", "dellstore2")
        _ConexionConBD = Nothing
        _Orden = Nothing
        _Lector = Nothing
    End Sub
    Public Sub Abrir()
        'Abrir la base de datos
        _ConexionConBD = New NpgsqlConnection(_strConexion)
        _ConexionConBD.Open()
    End Sub

    Public Sub Cerrar()
        ' Cerrar la conexión cuando ya no sea necesaria
        If (Not _Lector Is Nothing) Then
            _Lector.Close()
        End If
        If (Not _ConexionConBD Is Nothing) Then
            _ConexionConBD.Close()
        End If
    End Sub

    Public Function EjecutarDML(ByRef SQL As String) As NpgsqlDataReader
        ' Ejecutar DML
        _Orden = New NpgsqlCommand(SQL, _ConexionConBD)
        _Lector = _Orden.ExecuteReader()
        Return _Lector
    End Function



    Public Function EjecutarDDL(ByRef SQL As String) As Integer
        ' Ejecutar DDL
        Dim FilasAfectadas As Integer
        _Orden = New NpgsqlCommand(SQL, _ConexionConBD)
        FilasAfectadas = _Orden.ExecuteNonQuery()
        Return FilasAfectadas
    End Function

    Public Sub dispose()
        Me.Cerrar()
    End Sub

End Class
