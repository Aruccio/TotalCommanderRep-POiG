   M S B A M L   `   `   `  ����I  ETotalCommander, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:TotalCommander.ViewModelTotalCommander.ViewModel  5      9!clr-namespace:TotalCommander.ViewTotalCommander.View  5          TotalCommander.View.Panel   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5vm&clr-namespace:TotalCommander.ViewModel     5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      -local!clr-namespace:TotalCommander.View  5        � 	Resources  5
      -  'TotalCommander.ViewModel.ViewModelPanel 	  panel��%   &	          5   
   6   5      .��5      �  � DataContext# [  6   $��0,0,0,0q�60   .+�5   
   �� 
�������$��10,10,10,42q�6(   .+�5      �� -   5         ��Name$ textBlockPath��5      $��10q�6/   $��20��6;   $	��560��6G   $
��Left=�5      $	��Top=�6.   
�������
���� K� �� TextAlignment$
 Left=�5   :   $��15(�6O   {�.  ��5      ��  �� Path$ 	PathPanel� �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType" >��� 5      -   5         ��Name$ comboBoxOfDrives��5   +   $��	10,0,10,0q�6   $��1��5      $��12(�6!   
���� K�$��Stretch=�5      $��Center=�6/   ��5      �� $ PanelDrives� �� $ FindAncestor=�" >�	 �� SelectedItem	 5      �� $ 
PanelDrive� �� $ FindAncestor=�" >�5       �� 5!      $��0��6   
���� K�$��Stretch=�6=   $��
10,10,10,0q�5"      .+�5#      �� $
��Auto=�6   $	��440��6B   $��0q�6O   .��5$      �� -   5        $��13(�5*      
���� K�
�������$	��440��5,   A   ��5$      �� *	PanelOC+ �� $ FindAncestor=�" >�	 5'      �� *PanelListPath+ �� $ FindAncestor=�" >�5-      5.      5/      50      51      52      