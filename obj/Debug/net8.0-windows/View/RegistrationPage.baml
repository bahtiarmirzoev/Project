   M S B A M L   `   `   `  ����B  >Project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Project.ViewProject.View  5      #    Project.View.RegistrationPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Project.View     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a:md1http://materialdesigninxaml.net/winfx/xaml/themes  5      .��5
      � .+�5   
   �� $&�� https://i.imgur.com/wEDWchd.jpeg��6     J� Effect  5      -  'System.Windows.Media.Effects.BlurEffect  5         Radius$ 10Q�6   5      �� 5   
   $��20q�6   $��Center=�6!   $��Center=�6>   .+�5      ��  �� Orientation$ 
Horizontal=�6   $��0,0,0,10q�62   .+�5      �� 
��� ���$��0,0,0,2q�6.   ._�5      �� -   5        $��UsernameTextBox��5      $	��200��65   $��0q�6A    %  !MaterialDesignFloatingHintTextBox#��[  6U   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Username��6�   5      5      �� 5      $ 
Horizontal=�6   $��0,0,0,10q�62   .+�5      �� 
��� ���$��0,0,0,2q�6.   ._�5      �� -   5        $��NameTextBox��5      $	��200��61   $��0q�6=   #��[  6Q   $ 	Firstname��6�   5      5      �� 5      $ 
Horizontal=�6   $��0,0,0,10q�62   .+�5       �� 
��� ���$��0,0,0,2q�6.   ._�5!      �� -   5        $��SurnameTextBox��5!      $	��200��64   $��0q�6@   #��[  6T   $ Surname��6�   5"      5#      �� 5%      $ 
Horizontal=�6   $��0,0,0,10q�62   .+�5&      �� 
��� ���$��0,0,0,2q�6.   ._�5'      �� -   5        $��
FinTextBox��5'      $	��200��60   $��0q�6<   #��[  6P   $	 FIN��6�   5(      5)      �� 5+      $ 
Horizontal=�6   $��0,0,0,10q�62   .+�5,      �� 
��� ���$��0,0,0,2q�6.   ._�5-      �� -   5        $��PhoneTextBox��5-      $	��200��62   $��0q�6>   #��[  6R   $ Phone��6�   5.      5/      �� 51      $ 
Horizontal=�6   $��0,0,0,10q�62   .+�52      �� 
��� ���$��0,0,0,2q�6.   ._�53      G� -   5        $��PasswordBox��53   "   $	��200��65   $��0q�6A   $ Password��6U   54      55      �� 57      $��Register��6   $��Center=�6(   $��Center=�6E   $��0,20,0,0q�6`   $	��200��6r     MaterialDesignPaperButton#��[ 6   
��� ���6�   �� 59      $��Already have an account ?��6   $��Center=�69   $��Center=�6V   $��0,20,0,0q�6q   $	��200��6�   #��[ 6�   
��� ���
���   �6�   5:      5;      5<      