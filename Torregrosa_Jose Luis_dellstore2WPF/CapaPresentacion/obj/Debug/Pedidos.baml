   M S B A M L   `   `   `  ����K  GCapaPresentacion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:CapaPresentacionCapaPresentacion  5   	       CapaPresentacion.Pedidos   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:CapaPresentacion     5   	   -   5          � Title$  Pedidos��5	   	   $
��1280��6   $	��720��6&    � 
ResizeMode$ NoResize=�63      
ColorFondo#���   5
   	   .��5      � $	��419��6   $	��Top=�6   .+�5   
   � $��0,11,860,159q�6   .+�5      ��  �� CornerRadius$ 30��6   $	��696��6(   $
��Left=�64   ���	#9BFFFFFF���	#FFCDE4E5$��10,0,-292,0q�6~   ._�5      �� .+�5      � .+�5      �� 
�������$��1q�64   $ 	30,30,0,0��6H   $��40��6a   $�� 15,15,15,5q�6m   $	��Top=�6�   ��5      �� 5   "    �� EndPoint$ 0.5,1&�66    �� 
StartPoint$ 0.5,0&�6G   .��5   &   �  � Color$ 	#FFD6D6EB��63    � Offset$ 0Q�6E   � 5   &   $ 	#FFEF720D��63   $ 1Q�6E   5   #   ._�5      �� -   5         ��Name$ label15��5   $   $��Center=�65   $��Center=�6P   
�������$��Datos del cliente��6�   $��Calibri)�6�   $��21.333(�6�   $
��Bold"�6�   5      �� 5      -   5        $ label56��5       $��Nombre:��61   $
��Left=�6C   $	��Top=�6^   $��21.333(�6v   $��Microsoft Sans Serif)�6�   $��13,78,0,-52q�6�   �� 5      -   5        $ label1��5       $��Dirección:��60   $
��Left=�6E   $	��Top=�6`   $��21.333(�6x   $��Microsoft Sans Serif)�6�   $��15,117,0,-91q�6�   �� 5       -   5        $ label2��5        $��País:��60   $
��Left=�6@   $	��Top=�6[   $��21.333(�6s   $��Microsoft Sans Serif)�6�   $��18,195,0,-169q�6�   �� 5!      -   5        $ label3��5!       $��
Localidad:��60   $
��Left=�6E   $	��Top=�6`   $��21.333(�6x   $��Microsoft Sans Serif)�6�   $��18,156,0,-130q�6�   �� 5"      -   5        $ lbNombre��5"       $��Nombre de ejemplo��62   $
��Left=�6N   $��152,78,0,-52q�6i   $	��Top=�6   $��21.333(�6�   $��Microsoft Sans Serif)�6�   �� 5#      -   5        $ lbDir��5#       $��Dirección de ejemplo��6/   $
��Left=�6N   $��152,117,0,-91q�6i   $	��Top=�6�   $��21.333(�6�   $��Microsoft Sans Serif)�6�   �� 5$      -	   5        $ lbLocalidad��5$       $��Localidad de ejemplo��65   $
��Left=�6T   $��152,156,0,-130q�6o   $	��Top=�6�   $��21.333(�6�   $��Microsoft Sans Serif)�6�   �� 5%      -
   5        $ lbPais��5%       $��País de ejemplo��60   $
��Left=�6J   $��152,195,0,-169q�6e   $	��Top=�6}   $��21.333(�6�   $��Microsoft Sans Serif)�6�   5'      5(      5)      5*      � 5-   
   $��716,11,144,159q�6   .+�5.      �� $ 30��6   $	��536��6(   $
��Left=�64   ���	#9BFFFFFF���	#FFCDE4E5$��10,0,-132,0q�6~   ._�5/      �� .+�50      � .+�51      �� 
�������$��1q�64   $ 	30,30,0,0��6H   $��40��6a   $�� 15,15,15,5q�6m   $	��Top=�6�   ��52      �� 53   "   $ 0.5,1&�66   $ 0.5,0&�6G   .��54   &   � $ 	#FFD6D6EB��63   $ 0Q�6E   � 55   &   $ 	#FFEF720D��63   $ 1Q�6E   56   #   ._�58      �� -   5        $ label16��58   $   $��Center=�65   $��Center=�6P   
�������$��Datos del pedido��6�   $��Calibri)�6�   $��21.333(�6�   $
��Bold"�6�   59      �� 5;      -   5        $ label8��5;       $��Factura Número:��60   $
��Left=�6J   $	��Top=�6e   $��21.333(�6}   $��Microsoft Sans Serif)�6�   $��15,82,0,-56q�6�   �� 5<      -   5        $ lbNumFac��5<       $��0��62   $
��Left=�6>   $��211,82,0,-56q�6Y   $	��Top=�6o   $��21.333(�6�   $��Microsoft Sans Serif)�6�   �� 5=      -   5        $ label10��5=       $��Fecha:��61   $
��Left=�6B   $	��Top=�6]   $��21.333(�6u   $��Microsoft Sans Serif)�6�   $��15,121,0,-95q�6�   �� 5>      -   5        $ lbFecha��5>       $��
31/01/2016��61   $
��Left=�6F   $��211,121,0,-95q�6a   $	��Top=�6x   $��21.333(�6�   $��Microsoft Sans Serif)�6�   5@      5B      5C      5D      &   System.Windows.Controls.DataGrid  5F   
   -   5          Name$ dataGridLinesOrders��5F      	   CanUserReorderColumns	 . 
   CanUserResizeColumns
 .    CanUserResizeRows .  $��0,270,0,-121q�5G   u   ���	#9BFFFFFF���	#FFCDE4E5   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6�      AutoGenerateColumns .  ��6
   ��    Columns 5H      0  *System.Windows.Controls.DataGridTextColumn  5I      -   5        columnFecha��,  &System.Windows.Controls.DataGridColumn   Header$ Fecha��5I   _      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6;   ��  �� Path$ 	OrderDate�5K        5L      -   5        columnCantidad��$ Cantidad��5L   _    .  6=   �� $ Quantity�5N        5O      -   5        columnDescripcion��$ Descripción��5O   j    .  6A   �� $ Producto.Title�5Q        5R      -   5        columnI_Bruto��$ I. Bruto��5R   e    .  6<   �� $ Producto.Price�5T        5U      -   5        columnImporteBruto��$ Importe Bruto��5U   g    .  6B   �� $ PrecioTotal�5W      5Y        5[   
   -   5        $ 	dgTotales��5[       .  	 . 
 .  .     CanUserSortColumns .  $��0,540,0,-175q�5\   W   ���	#9BFFFFFF���	#FFCDE4E5$ * 6�   ��6
   ��  5]        5^      $ Base imponible��6%    .  6>   �� $ 	NetAmount�5`        5a      $ 	Impuestos��6%    .  69   �� $ Impuesto�5c        5d      $ Total impuestos��6%    .  6>   �� $	 Tax�5f        5g      $ Total factura��6%    .  6<   �� $ TotalAmount�5i      5k      �� 5o   
   -   5         ��Name$ button��5o      $��Añadir producto��69   $
��Left=�6S   $��41��6n   $��88,616,15,-238q�6z   $	��Top=�6�   $	��166��6�   $��16(�6�   $��Microsoft Sans Serif)�6�   �� 5p   
   -   5        $ 	btCambiar��5p      $��Cambiar��6<   $
��Left=�6N   $��41��6i   $��672,616,0,-238q�6u   $	��Top=�6�   $��86��6�   $��16(�6�   $��Arial)�6�   �� 5q   
   -   5        $ btBorrarLinea��5q      $��Borrar línea��6D   $
��Left=�6[   $��41��6v   $��832,616,0,-238q�6�   $	��Top=�6�   $	��109��6�    J� RenderTransformOrigin$ 0.5,0.5&�6�   $��16(�6�   $��Microsoft Sans Serif)�6�   �� 5r   
   -   5        $ btBorrarPedido��5r      $��Borrar pedido��6F   $
��Left=�6^   $��41��6y   $��972,616,0,-238q�6�   $	��Top=�6�   $	��120��6�   $��16(�6�   �� 5s   
   -   5        $ button4��5s      $��Salir��69   $
��Left=�6I   $��43��6d   $��1127,618,0,-242q�6p   $	��Top=�6�   $��16(�6�   $��86��6�   �� 5t   
   -   5         ��Name$ 
tbCantidad��5t        Mis_TextBox#��[ 6L   $��39��6q   $
��Left=�6}   $��472,618,15,-238q�6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��132��6�   $��21.333(�6�   �� 5u   
   -   5        $ label4��5u      $��Cambiar cantidad:��6    $
��Left=�6<   $��41��6W   $��287,620,0,-242q�6c   $	��Top=�6{   $��21(�6�   $��Microsoft Sans Serif)�6�   �� 5v   
   -   5         ��Name$ imgCantidad��5v      $
��Left=�6%   $��33��6@   $��621,620,0,-234q�6L   $	��Top=�6d   $��33��6|   5w      5x      