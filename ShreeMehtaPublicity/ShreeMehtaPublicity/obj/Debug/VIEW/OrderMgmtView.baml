   M S B A M L   `   `   `  ����N  JShreeMehtaPublicity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:ShreeMehtaPublicity.UtilityShreeMehtaPublicity.Utility  5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5      ,    &ShreeMehtaPublicity.VIEW.OrderMgmtView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=null@material1http://materialdesigninxaml.net/winfx/xaml/themes  5      :d2http://schemas.microsoft.com/expression/blend/2008  5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      =utility)clr-namespace:ShreeMehtaPublicity.Utility     5      ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5      -   5        $��OrderMgmtWindow��5
      |�.  ��.  
������ &   System.Windows.Media.TextOptions    TextRenderingMode$
  Auto=�5         TextFormattingMode$ Ideal=�63   $��13(�6Z   $��Regular"�6t      MaterialDesignFont#���   5        MaterialDesignBody#���  6@    � 	Resources 5      7   1ShreeMehtaPublicity.Utility.OrdrMdfyEnblConvertor  MdfyEnableConvertor7   1ShreeMehtaPublicity.Utility.OrdrCnclEnblConvertor  CnclEnableConvertor;   5ShreeMehtaPublicity.Utility.NoListVisibilityConvertor  NoListVisible1   +ShreeMehtaPublicity.Utility.AmountValidator  AmountValidator��%t   &	       &	      &	 &     &	 9       5   
   6(     5   
   6(     5   
   6,     5   
   6"   5      .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��AUTO �6   .+�5   
   �� -   5        $��
ListBorder��5      $��0��6#   ._�5      �  � ColumnDefinitions 5      �� 5      $	��250 �6'   �� 5      $��* �6'   .+�5"      �� $��0��6     FilterBorder#��[ 6)   ._�5#      � $��Stretch=�6    5$      �� 5%      $
��AUTO �6,   �� 5&      $��* �6,   �� 5'      $
��AUTO �6,   .+�5*      �� $��Filter��6      FilterLabel#��[ 61   ��.  6V   � 5+      $��1��6    5,      �� 5-   "   $
��AUTO �60   �� 5.   "   $
��AUTO �60   �� 5/   "   $
��AUTO �60   �� 50   "   $
��AUTO �60   �� 51   "   $
��AUTO �60   �� 52   "   $
��AUTO �60   .+�55      �� -   5         ��Name$ SiteList��55   4   $��0��6'     FilterComboBox#��[ 6F    �� DisplayMemberPath$ SiteName��6   �� IsTextSearchEnabled . )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 	Site Name��6U  	   
IsFloating	 . $��0��6�  ��6n   �� *Sites+
 �� UpdateSourceTrigger$
 PropertyChanged=� �� Mode$ TwoWay=� �� SelectedItem 6�   ��  �� Path$ SelectedSite�$ TwoWay=�$
 PropertyChanged=�6�  �� 57      -   5        $ 
ClientList��57   4   $��1��6'   #��[ 6H   $ 
ClientName��6"   . $ Client Name��6]  	 . $��1��6�  ��6p   �� *	Clients+$
 PropertyChanged=�$ TwoWay=� 6�   �� $ SelectedClient�$ TwoWay=�$
 PropertyChanged=�6�  �� 59      -   5        $��Amount��59   3   $��2��6&    	 FilterTextBox#��[	 6A   $ Amount (Rs.)��6�   	 . $��2��6,  ��6h   �� *Amount+$ TwoWay=�$
 PropertyChanged=� �� 	Converter# [ 6,  �� 5;      -   5        $ StatusComboBox��5;   4   $��3��6'   #��[ 6L    . $ Status��6G  	 . $��5��6�  ��6t   �� *ListOfStatus+$
 PropertyChanged=�$ TwoWay=� 6�   �� $ SelectedStatus�$ TwoWay=�$
 PropertyChanged=�6�  �� 5=      $��4��6'   $��Booking Dates :��64   $��	5 10 10 0q�6M   $��Stretch=�6`   $	��Top=�6~    
 FilterAvailSite#��[
 6�     FilterGroupBoxHeader#��[ 6�   .��5>   "   ��  �� Orientation$ Vertical=�6-   .+�5?   &   (  "System.Windows.Controls.DatePicker  -   5        $��	StartDate��5?   1     FilterDatePicker#��[ 6B      FirstDayOfWeek$ Monday=�6�   ��. $ 
Start Date��6�   	 . $��3��6G     SelectedDate 6l   �� *	StartDate+$ TwoWay=�   DisplayDate 6�   �� *DisplayStartDate+$ TwoWay=�.  (System.Windows.Interactivity.Interaction   Triggers 5@   *   /	  )System.Windows.Interactivity.EventTrigger	  5A   .    	  	EventName$ SelectedDateChanged��6=   .
  (System.Windows.Interactivity.TriggerBase 
  Actions. 5B   2   6  0System.Windows.Interactivity.InvokeCommandAction     Command 6H   �� *StartDateChangedCommand+5C   /   5E   '     5G   &   -   5        $��EndDate��5G   1   #��[ 6@   $ Monday=�6  ��. $ End Date��6�  	 . $��4��6%   6j   �� *	EndDate+$ TwoWay=�$
 PropertyChanged=� 6�   �� *DisplayEndDate+$ TwoWay=�$
 PropertyChanged=�   DisplayDateStart 6.  ��  �� ElementName$ 	StartDate��$ SelectedDate�{�6t  �� *EndDateEnable+$
 PropertyChanged=�$ TwoWay=�6%  5H   #   5I      � 5K      $��5��6#   $��0,10,0,0q�60    5L   "   �� 5M   &   $��* �67   �� 5N   &   $��* �67   .+�5P   "   �� -	   5         ��Name$ Search��5P   )   $��0��69   $��Search��6I   $��Stretch=�6|   $��Center=�6�   $��	10,0,10,0q�6�   $��6��6�   ��6Z   �� *SearchCommand+ J� InputBindings 5Q   &   �� 5R   *   
 �� Key$ Enter��65    �� Command 6A   �� *SearchCommand+5T   #   �� 5U   "   -
   5        $ Reset��5U   )   $��1��68   $��Reset��6H   $��Stretch=�6y   $��Center=�6�   $��	10,0,10,0q�6�   $��7��6�   ��6X   �� *ResetCommand+ 5V   &   �� 5W   *   $ Enter��65    6A   �� *ResetCommand+5Y   #   5Z      5[      �� 5]      $��2��6!   ._�5^      � $��Stretch=�6#   $��
20 0 20 20q�6A    5_   "   �� 5`   &   $��* �64   .+�5b   "   �� -   5        $ Place��5b   )   $��0��68   $��Place Order��6E   $��Stretch=�6[   $��Center=�6y   ��.  6�   5c      5d      5e      5f      �� 5h      -   5         ��Name$ 	OrderList��5h      $��1��6.     ListViewStyle#��[ 6>     ListViewItemStyle#��[ 6  ��6e   �� *ListOfOrders+$ OneWay=�$
 PropertyChanged=� 6�   �� *SelectedOrder+$ TwoWay=�$
 PropertyChanged=� �� View 5i      �� 5j      .P�5k      ��  �� Width$	 150��6-   $��Work Order No��69     ListViewItemData  �� CellTemplate#  [ 6�     ListViewColumnHeader! �� HeaderTemplate#! [ 6�   " �� DisplayMemberBinding" 6P   �� $ OrderSeqNum�$ OneWay=�6�   �� 5l      $	 200��6-   $
��Site��69   #  [ 6�   #! [ 6�   " 6G   �� $ OrderSite.SiteName�$ OneWay=�6�   �� 5m      $	 200��6-   $��Client��69   #  [ 6�   #! [ 6�   " 6I   �� $ OrderClient.ClientName�$ OneWay=�6�   �� 5n      $	 150��6-   $��Amount (Rs.)��69   #  [ 6�   #! [ 6�   " 6O   �� $ OrderTotalAmount�$ OneWay=�# �� StringFormat$
# 0.00��6�   �� 5o      $	 150��6-   $��
Start Date��69   #  [ 6�   #! [ 6�   " 6M   �� $ OrderStartDate�$ OneWay=�$# dd - MMM - yyyy��6�   �� 5p      $	 150��6-   $��End Date��69   #  [ 6�   #! [ 6�   " 6K   �� $ OrderEndDate�$ OneWay=�$# dd - MMM - yyyy��6�   �� 5q      $	 150��6-   $��Status��69   #  [ 6�   #! [ 6�   " 6I   �� $ OrderStatus�$ OneWay=�6�   �� 5t      $ 50��6-     5u   "   �� 5v   &   .R�5w   *   �� $
 Mdfy��61   -   5          ListButtonStyle#��[ 5w   R   $ � ToolTip$
$ Edit��6{   % ^� ShowDuration$
% 1500��6�   ��.  {�6�   �� *OrderStatus+# [ & �� ConverterParameter$& OrderStatus��$
 PropertyChanged=�$ TwoWay=�.��5x   .   '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=null]]'   Kind$' Pencil=�6@     ListButtonIconStle#��[ 6N   {�6z   �� $
 Mdfy��$ 	IsEnabled�5y   +   5z   '   5|      �� 5}      $ 50��6-     5~   "   �� 5   &   .R�5�   *   �� $
 Cncl��61   -   5        #��[ 5�   R   $
$ Edit��6{   $
% 1500��6�   ��.  {�6�   �� *OrderStatus+# [ $& OrderStatus��$
 PropertyChanged=�$ TwoWay=�.��5�   .     $' CloseBox=�6@   #��[ 6P   {�6|   �� $
 Cncl��$ 	IsEnabled�5�   +   5�   '   5�      �� 5�      $ 50��6-     5�   "   �� 5�   &   .R�5�   *   �� $
 View��61   -   5        #��[ 5�   R   $
$ View��6{   $
% 1500��6�   ��.  .��5�   .     $	' Eye=�6@   #��[ 6K   {�. 6w   5�   +   5�   '   5�      5�      5�      �� 5�      $��1��6     NoListViewBorder#��[ 6�   y�6)   �� *ListOfOrders.Count+# [ $
 PropertyChanged=�._�5�      �� $��No Orders are Present��6      NoListViewText#��[ 6=   5�      5�      5�      5�      5�      