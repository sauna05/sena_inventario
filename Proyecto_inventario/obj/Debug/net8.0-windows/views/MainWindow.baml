   M S B A M L   `   `   `  ����N  JProyecto_inventario, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Proyecto_inventarioProyecto_inventario  5   	   *    $Proyecto_inventario.views.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:Proyecto_inventario     5   	     � Title$$  sistema de gestion de prestamo��5   	   $	��600��60   $	��900��6=   .��5	      �  � ColumnDefinitions 5
   
   �� 5      �� 5       � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   � $��0��6   $��10,10,10,10q�6   $��2��61    5      �� 5      $
��auto �6#   �� 5      $��* �6#    5      �� 5      $
��Auto �6    .+�5      �� $��0��6   $��0��6$   $��Buscar:��61   $��5,5,0,5q�6C   �� 5      -   5         ��Name$ 
txtbuscado��5   3   $��1��6   $��0��6&   $��5,5,5,5q�6G   
���   �6l   5       &   System.Windows.Controls.DataGrid  5#   
   -   5        $��dataproductos��5#         
IsReadOnly$
 True��5$         CanUserAddRows$ False��5%         CanUserDeleteRows$ False��5&         AutoGenerateColumns$ False��5'      $��10,62,10,10q�5(      $   HorizontalScrollBarVisibility$
 Auto=�5)      $��1��5*      $��2��6   	   Columns	 5+      0  *System.Windows.Controls.DataGridTextColumn  5-      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Código��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6L   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *cd+6L     5.      $
 Nombre��6%   $ * 6L    65   �� *nm+6L     5/      $
 Cantidad��6%   $ * 6N    67   �� *ec+6N     50      $
 Persona��6%   $ * 6M    66   �� *pn+6M     51      $
 Estado��6%   $ * 6L    65   �� *es+6L     52      $
 
Categoría��6%   $ * 6O    68   �� *cg+6O   4  .System.Windows.Controls.DataGridTemplateColumn  55      $
 Acciones��6)      CellTemplate 56      �� 57      .R�58      ��  �� Orientation$ 
Horizontal=�6)   .+�59   "   ��  ��Name$ btneliminar��6)   -   5        $��5q�59   y   ��6Y   �� *id+.��5:   &   �� $��16��6,   $]��WC:\Users\user\source\repos\Proyecto_inventario\Proyecto_inventario\sources\eliminar.png��67   $��0,0,5,0q�6�   6�   5;   #   �� 5<   "   $��	btneditar��6A   -   5        $��5q�5<   R   ��6]   �� *id+.��5=   &   �� $��16��6,   $[��UC:\Users\user\source\repos\Proyecto_inventario\Proyecto_inventario\sources\editar.png��67   $��0,0,5,0q�6�   6�   5>   #   5?      5@      5B      5D      �� 5E   
   -   5        $ 
btnagregar��5E      $��Agregar new��6%   $
��Left=�6;   $��	60,10,0,0q�6V   $��1��6i   $	��Top=�6v   $	��122��6�   6�   �� 5F   
   -   5        $��combo_categoria��5F      $
��Left=�6*   $��
283,10,0,0q�6E   $��1��6Y   $	��Top=�6f   $	��120��6~   6�   5G      5H      