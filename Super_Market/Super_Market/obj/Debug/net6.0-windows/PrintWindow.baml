   M S B A M L   `   `   `  ����G  CSuper_Market, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Super_MarketSuper_Market  5   	       Super_Market.PrintWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Super_Market     5   	     � AllowsTransparency$
  True��5
   	    � WindowStyle$
 None=�5   	   ��5	   	   Z� .��5      (� .��5   
   � .+�5   
   � -   5        $��griddata��5      ���	#FFD4D1D1$	��800��66    � ColumnDefinitions 5      �� 5      $
��279* �6#   62   �� 5      $
��136* �6#    � RowDefinitions 5      �� 5      $	��150 �6    6/   �� 5      $	��415 �6    6/   �� 5      6"   .+�5      �� $	��Top=�6   $��0��61    �� Orientation$ 
Horizontal=�6>   $��2��6W   .+�5      �� $��30(�6   $��Center=�6&   .��6A   Bon6F   �� 5      -   5         ��Name$ 
bon_number��5      $��25(�61   $��	30 0 0 0 q�6@   $
��Bold"�6S   6h   5      �� 5      $��Bottom=�6   $ 
Horizontal=�64   $��2��6M   .+�5       �� $��30(�6   .��6&   Date:6-   �� 5!      -   5        $��TxtData��5!      $��30(�6+   $
��Bold"�69   $��	80 15 0 0q�6K   6a   5"      &   System.Windows.Controls.DataGrid  5$      -   5        $��printDataGraid��5$   .   $��15,15,15,15q�6   $��1��6D   $��2��6Q      AutoGenerateColumns$ False��6e      
IsReadOnly$
 True��6�   $��30(�6�    � 	Resources 5%      =  7System.Windows.Controls.Primitives.DataGridColumnHeader	 �� 
TargetType
 �� Property �� Value��%�   '        �� 5&      "	  6   .�5'      �� 
 � ��$ SemiBold"�67   6J   �� 5(      
 � ��$ 30(�65   6B   �� 5)      
 � ��$ 0,0,1,2q�6<   6N   5+      5,         Columns 5-      0  *System.Windows.Controls.DataGridTextColumn  5.      -   5        productname��,  &System.Windows.Controls.DataGridColumn   Header$ Product��5.   >      Width5  /System.Windows.Controls.DataGridLengthConverter$	 230 6O   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6[   ��  �� Path$
 Name�6{     5/      $ Quantity��6)   $	 190 6;    6G   �� $ Quantity�6k     50      $ Price��6)   $	 190 68    6D   �� $ SellingPrice�6m     51      $ Total��6)   $	 190 68    6D   �� $ 
TotalPrice�6j   53      �� 54      $��2��6   $��2��6&   $ 
Horizontal=�6:   .+�55      �� $ 
Horizontal=�6   $	��250��66   .+�56      �� $��25(�6   
���   �.��6=   Total Price:6K   �� 57      -   5        $��
totalprice��57   !   $��30(�63   6C   58      5:      5;      �� 5<      -   5        ���	#FF4646DA$	��150��5<   -   $��30(�69   $��601,685,79,65q�6G   $��50��6^   .��6   Save6�   5=      5>      5?      