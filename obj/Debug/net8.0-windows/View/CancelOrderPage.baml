   M S B A M L   `   `   `  ����B  >Project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Project.ViewProject.View  5      "    Project.View.CancelOrderPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Project.View     5      .��5	      �   � RowDefinitions  5
   
   �� 5      $	��41* �6   �� 5      $	��34* �6   .+�5   
   �� $)��#/image/registrationpagetrendyol.jpg��6   $��2��6=    J� Effect 5      -  'System.Windows.Media.Effects.BlurEffect  5         Radius$ 10Q�6   5      �� 5   
   $��Cancel Order��6   $��20(�6(   $
��Bold"�66   $��Center=�6H   $��
0,20,0,182q�6e   $	��162��6y   
���   �6�   �� 5   
   $��30,64,20,20q�6   $��2��6*   �� 5   
   $��
0,53,2,103q�6   $��2��6+   .��5      �� $��1��6    �� SelectionMode$ Single=�5      $��17(�5      $
��Bold"�5      $��0,0,0,0q�5      $	��288��5      $	��798��6   ��5      �� *Order+ �� SelectedItem 5      �� *SelectedOrder+��5      �� 5       .R�5!      ]� .+�5"      �� $��1��5#      .+�5$   "   �� $��Name: ��6(   �� 5%   "   $��	Surname: ��6(   �� 5&   "   $��FIN: ��6(   �� 5'   "   $��Email: ��6(   �� 5(   "   $��Product ID: ��6(   �� 5)   "   $��Product name: ��6(   �� 5*   "   $��Order Date: ��6(   �� 5+   "   $��Status: ��6(   5-      �� 5.      $��1��5/      .+�50   "   �� ��6(   �� *
Users.Name+�� 51   "   ��6(   �� *Users.Surname+�� 52   "   ��6(   �� *	Users.FIN+�� 53   "   ��6(   �� *Users.Email+�� 54   "   ��6(   �� *	ProductId+�� 55   "   ��6(   �� *	Product+�� 56   "   ��6(   �� *	Created+�� 57   "   ��6(   �� *Status+58      59      5:      5<      5=      �� 5?   
   $��Go Back��5A      $��640,152,10,20q�6   $	��150��6/   
���  ��
���  ��$��2q�6^   $��1��6r   ��5@      �� *Exit+5A   r   �� 5B   
   $��Delete Order��5D      $	��150��6$   $��472,152,178,20q�60   
���  ��
���  ��$��2q�6k    J� RenderTransformOrigin$ 1.005,0.776&�6   $��1��6�   ��5C      �� *Delete+5D   �   5E      5F      