   M S B A M L   `   `   `  ����  ShreeMehtaPublicity4    .ShreeMehtaPublicity.VIEW.TodayTomorrowSiteView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -   5        ��.  .��5
      �   � RowDefinitions  5   
   �� 5      $��70 �6   �� 5      $��* �6   .+�5   
   �� $��0��6      HeaderBorder#��[  6   $��Stretch=�6D   $��Stretch=�6b   ._�5      �  � ColumnDefinitions 5      �� 5      $��* �6'   �� 5      $
��AUTO �6'   .+�5      �� $��Center=�6   $��Stretch=�63   ��.   
 Header#��[ 6�   ��6Q   �� *ActionLable+6�   �� 5      -   5         ��Name$ OkButton��5      $��1��6+   $��X��6;     CloseButton#��[ 6�   5      5      �� 5   
   $��1��6     
GridBorder#��[ 6   $��70,20,70,10q�6B   ._�5      � $��0,5,0,0q�6   $��Stretch=�6$     5      �� 5      $��* �6$   .+�5!      �� $��0��6   $��Stretch=�6(   $��Stretch=�6F   $��5,10,5,0q�6b    �� AlternationCount$ 2��6�   ��6t   �� *
SiteList+ �� Mode$ OneWay=� �� View 5"      �� 5#        GridViewColumnHeaderStyle! �� ColumnHeaderContainerStyle# [ 6#   .P�5$      ��  �� Width$	 150��6-   .��5%   "   �� $��Order Id��67    �� CellTemplate 5&   "   �� 5'   &   .R�5(   *   ��   ListItem#��[ 6c   ��64   �� 	 �� Path$	 OrderSeqNum�$ TwoWay=�6c   5)   '   5+      �� 5,      $	 200��6-   .��5-   "   �� $
��Site��67    5.   "   �� 5/   &   .R�50   *   �� #��[ 6j   ��64   �� $	 OrderSite.SiteName�$ TwoWay=�6j   51   '   53      �� 54      $	 200��6-   .��55   "   �� $��Client��67    56   "   �� 57   &   .R�58   *   �� #��[ 6n   ��64   �� $	 OrderClient.ClientName�$ TwoWay=�6n   59   '   5;      �� 5<      $	 150��6-   .��5=   "   �� $��Amount (Rs.)��67    5>   "   �� 5?   &   .R�5@   *   �� #��[ 6x   ��64   �� $	 OrderAmount�$ TwoWay=�
 �� StringFormat$

 0.00��6x   5A   '   5C      �� 5D      $	 150��6-   .��5E   "   �� $��
Start Date��67    5F   "   �� 5G   &   .R�5H   *   �� #��[ 6   ��64   �� $	 OrderStartDate�$ TwoWay=�$
 
dd-MM-yyyy��6   5I   '   5K      �� 5L      $	 150��6-   .��5M   "   �� $��End Date��67    5N   "   �� 5O   &   .R�5P   *   �� #��[ 6}   ��64   �� $	 OrderEndDate�$ TwoWay=�$
 
dd-MM-yyyy��6}   5Q   '   5S      �� 5T      $	 150��6-   .��5U   "   �� $��Status��67    5V   "   �� 5W   &   .R�5X   *   �� #��[ 6c   ��64   �� $	 OrderStatus�$ TwoWay=�6c   5Y   '   5[      5\      5^      5_      5`      5a      5b      