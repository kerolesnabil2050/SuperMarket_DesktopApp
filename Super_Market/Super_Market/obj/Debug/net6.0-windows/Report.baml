   M S B A M L   `   `   `  ����b  ^Syncfusion.SfChart.WPF, Version=20.4600.0.51, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89eGclr-namespace:Syncfusion.UI.Xaml.Charts;assembly=Syncfusion.SfChart.WPFSyncfusion.UI.Xaml.Charts  5      G CSuper_Market, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Super_MarketSuper_Market 5         Super_Market.Report   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ^
syncfusionGclr-namespace:Syncfusion.UI.Xaml.Charts;assembly=Syncfusion.SfChart.WPF     5      ,localclr-namespace:Super_Market     5      .��5      (� .��5   
   ��   �� CornerRadius$  35��6   $��	0 0 0 -17q�6#    �� Padding$ 40q�66   
������� J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         ShadowDepth$ 1Q�6#      
BlurRadius$ 20Q�63      Opacity$	 0.4Q�6C   6S   ._�5      � $
��1400��6   $	��900��6     � ColumnDefinitions 5      �� 5      $
��1.8* �6'   66   �� 5      6)    � RowDefinitions 5      �� 5      $	��120 �6$   63   �� 5      $	��110 �6$   63   �� 5      6&   �� 5      $��2* �6$   62   .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��30(�6   .��6*   Date:61   (  "System.Windows.Controls.DatePicker  5      -   5        $
��Date��5   !   $	��250��6.   $��30(�6:   $	��Top=�6H   ���	#FFE2DBF4$��	80 15 0 0q�6w   6�   5       �� 5!      $ 
Horizontal=�6   $��1��66   .+�5"      �� $��30(�6   .��6*   
Suppliers:66   �� 5#      -   5        $��Combobox_Suppliers��5#      $��20(�69   $	��250��6H   $	��Top=�6T   ���	#FFE2DBF4$��15q�6�   ��5$      �� 5%      .R�5&   "   �� .+�5'   &   �� ��60   �� 	 �� Path$
	 Name�6M   5(   #   5)      5+      5,      �� 5.      $��1��6   $ 
Horizontal=�6*   $��50��6C   $	��Top=�6O   $��Center=�6g   $��2��6�   .+�5/      �� -   5        
 ��Name$
 
sellinvoce��5/      $��30(�61   $��	30,0,70,0q�6@   $	��200��6S   $��50��6_   ���	#FF866AC9.��6�   Sell Invoce6�   �� 50      -   5        $
 suppliseinvoc��50      $��30(�64   $��	30,0,70,0q�6C   $	��250��6W   $��50��6c   ���	#FF866AC9.��6�   Supplier Invoce6�   51      &   System.Windows.Controls.DataGrid  52      -   5          Name$ datagrid��52   /   $��
-20,0,20,0q�6   $��25(�6A   $��2��6O      
IsReadOnly$
 True��6\   $��2��6n      AutoGenerateColumns$ False��6�    � 	Resources 54      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value��%  '        �� 55      "  6    .�56      ��  � �� �	#FFE2DBF46O   �� 57       � ��$ SemiBold"�6;   6N   �� 58       � ��$ 30(�69   6F   �� 59       � ��$ 	15,0,20,0q�67   6K   �� 5:       � ��$ 0,0,1,2q�6@   6R   5<      5=      5?      �� 5@      $��2��6   $��1��6)   $��Center=�69   $��Center=�6T   $��40(�6q   $��Medium"�6   
����������	#FF866AC9Products Quentites6�   '   !Syncfusion.UI.Xaml.Charts.SfChart  5A      $��3��6&   $��1��63      Series. 5C      ,   &Syncfusion.UI.Xaml.Charts.ColumnSeries  -   5        $��Reportproduct��5C   /   /   )Syncfusion.UI.Xaml.Charts.ChartSeriesBase   EnableAnimation$
 True��6D      AnimationDuration$ 00:00:03h�6[      XBindingPath$
 Name��5E      ,   &Syncfusion.UI.Xaml.Charts.XyDataSeries   YBindingPath$ Quantity��6   5G      5H      5I      5J      5K      