   M S B A M L   `   `   `  ����I  ETotalCommander, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:TotalCommanderTotalCommander  5   	   C&clr-namespace:TotalCommander.ViewModelTotalCommander.ViewModel  5   	   9!clr-namespace:TotalCommander.ViewTotalCommander.View  5	   	       TotalCommander.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   (localclr-namespace:TotalCommander  5   	   /vm&clr-namespace:TotalCommander.ViewModel  5   	   ,view!clr-namespace:TotalCommander.View  5	   	     � Title$  TotalCommander��5   	   $	��600��6    $
��1000��6-   
���� K� � 	Resources 5      *  $TotalCommander.ViewModel.ViewModelTC   vmp��%   &	          5   
   6   5      .��5      �  � DataContext# [  6    � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $��1* �6   .+�5   
      TotalCommander.View.Panel  -   5          Name$	 ob1��5      $��0��6"      	PathPanel 5      ��  �� Path$ VMLeft.OriginalPath� �� Mode$ TwoWay=�   
PanelDrive 5      �� $ VMLeft.CurrentDrive�$ TwoWay=�	   PanelDrives		 5      �� $ VMLeft.CurrentDrives�
.  (System.Windows.Interactivity.Interaction
   Triggers
 5      /  )System.Windows.Interactivity.EventTrigger  5          	EventName$ MyEvent��6!   .  (System.Windows.Interactivity.TriggerBase   Actions. 5!      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6,   �� *VMLeft.Clear+5"      5$        5&   
   -   5        $	 ob2��5&      $��1��6"    5'      �� $ VMRight.OriginalPath�$ TwoWay=� 5(      �� $ VMRight.CurrentDrive�$ TwoWay=�		 5)      �� $ VMRight.CurrentDrives�

 5+        5,      $ MyEvent��6!   . 5-         6,   �� *VMRight.Clear+5.      51      �� 56   
   -   5         ��Name$ 
buttonCopy��56      $	��100��6%   $��	10,5,10,5q�61   
�������
���   �$��Kopiuj��58      $��Center=�6&   $��25��59   2   $��Bottom=�6>   ��6   �� *Copy+6>   5;      5<      