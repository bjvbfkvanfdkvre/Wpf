   M S B A M L   `   `   `  ����S  OЖильеНаВыбор, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:ЖильеНаВыборЖильеНаВыбор  5   	   U/clr-namespace:ЖильеНаВыбор.Commands!ЖильеНаВыбор.Commands  5   	   *    $ЖильеНаВыбор.WindowAdmin   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:ЖильеНаВыбор     5   	   Ccommand/clr-namespace:ЖильеНаВыбор.Commands     5   	   -   5          � Title$  WindowAdmin��5
   	   $	��450��6   $	��800��6*    J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5        4  .ЖильеНаВыбор.Commands.DataCommands   Undo   Command# Z 5      5        5   
   -   5           Edit# Z 5      5        5   
   -   5           Delete# Z 5      5        5   
   -   5        
   New# Z 5      5        5   
   -   5           Save# Z 5      5        5   
   -   5           Refresh# Z 5      5   	   .��5"      �� 
�������.+�5$   
   o� .@�5%      m� $��Действие��6   $��3q�6)   .@�5&      m� $��Отменить��6   	 m� Command#	 Z 6-   6^   �� 5'      6   m� 5(      $��Создать��6   #	 Z 6,   6\   m� 5)      $ ��Редактировать��6   #	 Z 62   6c   m� 5*      $��Сохранить��6   #	 Z 6.   6_   m� 5,      $��Обновить��6   #	 Z 6-   6a   �� 5-      6   m� 5.      $��Удалить��6   #	 Z 6,   6_   5/      50      �� 51   
   -   5        
 ��Name$
 KvartiraButton��51      $��25��53      .��6   Квартиры6(   �� 54   
   -	   5        $
 ArendaButton��54      $��25��56   	   .��6   Аренда6   &   System.Windows.Controls.DataGrid  57   
   -
   5        $��DataGridKvartira��57         AutoGenerateColumns .  $
��Left=�5:      $
��1000��5;      $	��295��6      RowBackground
 �����   AlternatingRowBackground
 �����
�������$��3q�5?         	RowHeight$ 25Q�5@       � Cursor$
 Hand��5A         CanUserAddRows .     CanUserDeleteRows .  $	��757��5C   &   ��58      ��    Columns 5D      0  *System.Windows.Controls.DataGridTextColumn  5E      ,  &System.Windows.Controls.DataGridColumn   Header$ Код квартиры��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6;   �� *КодКвартиры+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�  5F      $ Описание��6%    67   �� *Описание+$ TwoWay=�$ PropertyChanged=�  5G      $ Этаж��6%    63   �� *
Этаж+$ TwoWay=�$ PropertyChanged=�  5H      $ 
Адрес��6%    64   �� *
Адрес+$ TwoWay=�$ PropertyChanged=�  5I      $ Цена за месяц��6%    6<   �� *
Цена+$ TwoWay=�$ PropertyChanged=�  5J      $! Номер квартиры��6%    6=   �� *НомерКвартиры+$ TwoWay=�$ PropertyChanged=�5L        5M   
   -   5        $��DataGridArenda��5M       .  $
��Left=�5P      $
��1000��5Q      $	��295��6   
 �����
 �����
�������$��3q�5U      $ 25Q�5V      $
 Hand��5W       .   .  $	��757��5Y      $y�Hidden=�5Z      ��5N      ��  5[        5\      $ Номер аренды��6%    6;   �� *КодАренды+$ TwoWay=�$ PropertyChanged=�  5]      $ Дата заезда��6%    6:   �� *ДатаЗаезда+$ TwoWay=�$ PropertyChanged=�  5^      $ Дата выезда��6%    6:   �� *ДатаВыезда+$ TwoWay=�$ PropertyChanged=�  5_      $ Статус��6%    65   �� *Статус+$ TwoWay=�$ PropertyChanged=�5a      5c      5d      