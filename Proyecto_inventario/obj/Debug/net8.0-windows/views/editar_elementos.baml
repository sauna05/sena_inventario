   M S B A M L   `   `   `  ����N  JProyecto_inventario, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Proyecto_inventario.viewsProyecto_inventario.views  5   	   0    *Proyecto_inventario.views.editar_elementos   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:Proyecto_inventario.views     5   	     � Title$  editar_elementos��5   	   $	��450��6"   $	��800��6/   .��5	      � $��243,20,204,5q�6    � ColumnDefinitions 5
   
   �� 5      �� 5       � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   �� -   5        $��persona_encargada��5      $��Center=�6,   $��1��6I   $��Center=�6V   $	��120��6q   $��1��6}   6�   �� 5   
   -   5         ��Name$ 
codigo_txt��5      $��Center=�6&    �� TextWrapping$
 Wrap=�6C   $��Center=�6X   $	��120��6s   6   �� 5   
   -   5        $��	categoria��5      $��Center=�6$   $��Center=�6A   $	��120��6\   $��1��6h   6u   �� 5   
   -   5        $��estado��5      $��Center=�6!   $��2��6>   $��Center=�6K   $	��120��6f   6r   �� 5   
   -   5        $ txt_cantidad��5      $��Center=�6(   $��0,18,0,0q�6E   $
 Wrap=�6W   $	��Top=�6l   $	��120��6�   $��2��6�   $��1��6�   �� 5   
   -   5        $ 
txt_nombre��5      $��Center=�6&   $
 Wrap=�6C   $��Center=�6X   $	��120��6s   $��1��6   6�   �� 5   
   -   5        $��
btn_editar��5      $��editar��6#   $��2��64   $��Center=�6H   $��0,10,0,0q�6e   $��3��6w   $	��Top=�6�   $	��334��6�   6�   5       5!      