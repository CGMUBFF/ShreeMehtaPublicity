   M S B A M L   `   `   `  ����N  JShreeMehtaPublicity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:ShreeMehtaPublicity.UtilityShreeMehtaPublicity.Utility  5      -    'ShreeMehtaPublicity.VIEW.ClientMgmtView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=null@material1http://materialdesigninxaml.net/winfx/xaml/themes  5      :d2http://schemas.microsoft.com/expression/blend/2008  5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      =utility)clr-namespace:ShreeMehtaPublicity.Utility     5      -   5        $��ClientMgmtWindow��5	      |�.  ��.  
������ &   System.Windows.Media.TextOptions    TextRenderingMode$
  Auto=�5
         TextFormattingMode$ Ideal=�63   $��13(�6Z   $��Regular"�6t      MaterialDesignFont#���   5        MaterialDesignBody#���  6@    � 	Resources 5      1   +ShreeMehtaPublicity.Utility.StatusConvertor  StatusConverter;   5ShreeMehtaPublicity.Utility.NoListVisibilityConvertor  NoListVisible��%:   &	       &	        5   
   6"     5   
   6,   5      .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��AUTO �6   .+�5   
   �� -   5        $��
ListBorder��5      $��0��6#   ._�5      �  � ColumnDefinitions 5      �� 5      $	��250 �6'   �� 5      $��* �6'   .+�5      �� $��0��6     FilterBorder#��[ 6)   ._�5       � $��Stretch=�6    5!      �� 5"      $
��AUTO �6,   �� 5#      $��* �6,   �� 5$      $
��AUTO �6,   .+�5'      �� $��Filter��6      FilterLabel#��[ 61   ��.  6V   � 5(      $��1��6    5)      �� 5*   "   $
��AUTO �60   �� 5+   "   $
��AUTO �60   �� 5,   "   $
��AUTO �60   .+�5/      �� -   5        $��Client��5/   &   $��0��64     FilterTextBox#��[ 6A   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Client Name��6�      
IsFloating . $��0��6  ��6h   �� *fClientName+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6  �� 51      -   5        	 ��Name$	 StatusComboBox��51   4   $��1��6'     FilterComboBox#��[ 6L   
 �� IsTextSearchEnabled
 . $ Status��6H   . $��1��6�  ��6t   �� *ListofStatus+$ PropertyChanged=�$ TwoWay=� �� SelectedItem 6�   ��  �� Path$ fSelectedStatus�$ TwoWay=�$ PropertyChanged=�6�  � 53      $��2��6#   $��0,10,0,0q�60    54   "   �� 55   &   $��* �67   �� 56   &   $��* �67   .+�58   "   �� -   5         ��Name$ Search��58   )   $��0��69   $��Search��6I   $��Stretch=�6|   $��Center=�6�   $��	10,0,10,0q�6�   $��2��6�   ��6Z   �� *SearchCommand+ J� InputBindings 59   &   �� 5:   *   
 �� Key$ Enter��65    �� Command 6A   �� *SearchCommand+5<   #   �� 5=   "   -   5        $ Reset��5=   )   $��1��68   $��Reset��6H   $��Stretch=�6y   $��Center=�6�   $��	10,0,10,0q�6�   $��3��6�   ��6X   �� *ResetCommand+ 5>   &   �� 5?   *   $ Enter��65    6A   �� *ResetCommand+5A   #   5B      5C      �� 5E      $��2��6!   ._�5F      � $��Stretch=�6#   $��
20 0 20 20q�6A    5G   "   �� 5H   &   $��* �64   .+�5J   "   �� -   5        $	 Add��5J   )   $��0��66   $	��Add��6C   $��Stretch=�6Q   $��Center=�6o   $��4��6�   ��.  6�   5K      5L      5M      5N      �� 5P      -   5        $��
ClientList��5P      $��1��6-     ListViewStyle#��[ 6=    	 ListViewItemStyle#��[	 6  ��6d   �� *ListofClients+$ OneWay=�$ PropertyChanged=� 6�   �� *SelectedClient+$ TwoWay=�$ PropertyChanged=� �� View 5Q      �� 5R      .P�5S      ��  �� Width$	 100��6-   $��	Client Id��69    
 ListViewItemData �� CellTemplate# [
 6�     ListViewColumnHeader �� HeaderTemplate# [ 6�    �� DisplayMemberBinding 6L   �� $ ClientSeqNum�$ OneWay=�6�   �� 5T      $	 200��6-   $
��Name��69   # [
 6�   # [ 6�    6G   �� $ 
ClientName�$ OneWay=�6�   �� 5U      $	 150��6-   $��Landline No.��69   # [
 6�   # [ 6�    6O   �� $ ClientLandline�$ OneWay=�6�   �� 5V      $	 150��6-   $��
Mobile No.��69   # [
 6�   # [ 6�    6M   �� $ ClientMobile�$ OneWay=�6�   �� 5W      $	 150��6-   $��	E-Mail Id��69   # [
 6�   # [ 6�    6L   �� $ 
ClientMail�$ OneWay=�6�   �� 5X      $	 200��6-   $��Address��69   # [
 6�   # [ 6�    6J   �� $ ClientAddress�$ OneWay=�6�   �� 5Y      $	 200��6-   $��Branch��69   # [
 6�   # [ 6�    6I   �� $ ClientBranch�$ OneWay=�6�   �� 5Z      $ 50��6-    5[   "   �� 5\   &   .R�5]   *   �� $
 Mdfy��61   -	   5          ListButtonStyle#��[ 5]   S    � ToolTip$
 Edit��6|    ^� ShowDuration$
 1500��6�   ��.  .��5^   .   '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=null]]   Kind$ Pencil=�6@     ListButtonIconStle#��[ 6N   {�. 6z   5_   +   5`   '   5b      �� 5c      $ 50��6-    5d   "   �� 5e   &   .R�5f   *   �� $
 View��61   -
   5        #��[ 5f   S   $
 View��6}   $
 1500��6�   ��.  .��5g   .     $	 Eye=�6@   #��[ 6K   {�. 6w   5h   +   5i   '   5k      �� 5l      $	 150��6-    5m   "   �� 5n   &   .R�5o   *   ��  �� Orientation$ 
Horizontal=�65   $��Right=�6N   $��0 0 5 0q�6j   .+�5p   .   d� $��switch��6;   -   5          ListStatusToggleStyle#��[ 5p   I   ��.   d� 	IsChecked 6x   �� $ ClientStatus� �� 	Converter# [ $ OneWay=�6�   �� 5q   .   ��68   �� $ ClientStatus�$ OneWay=���5r   2   �� 5s   6     ListStatusToggleTextStyle �� BasedOn# [ 6<    �� 
TargetType" ��6q    �� Triggers 5t   :   �� 5u   >    �� Binding 6J   �� *	IsChecked+  �� ElementName$  switch��! �� Value! true6|   .a�5v   B   �� " �� Property" � ��  WindowTitleColorBrush# �� Value## [ 6_   5w   ?   �� 5x   >    6J   �� *	IsChecked+$  switch��	! false6|   .a�5y   B   �� " � ��
# �����6_   5z   ?   5|   7   5~   /   5   +   5�   '   5�      5�      5�      �� 5�      $��1��6     NoListViewBorder#��[ 6�   y�6)   �� *ListofClients.Count+# [ $ PropertyChanged=�._�5�      �� $��No Clients are Present��6      NoListViewText#��[ 6>   5�      5�      5�      5�      5�      