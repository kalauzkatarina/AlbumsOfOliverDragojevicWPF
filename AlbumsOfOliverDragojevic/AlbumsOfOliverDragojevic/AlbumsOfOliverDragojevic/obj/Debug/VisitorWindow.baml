   M S B A M L   `   `   `  ����S  OAlbumsOfOliverDragojevic, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:AlbumsOfOliverDragojevicAlbumsOfOliverDragojevic  5      ,    &AlbumsOfOliverDragojevic.VisitorWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:AlbumsOfOliverDragojevic     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      -   5          � Title$  Details about the album��5      $	��650��5	      $	��500��5
       � AllowsTransparency . 
������  � SizeToContent$ WidthAndHeight=�5       � WindowStartupLocation$ CenterScreen=�5       � WindowStyle$
 None=�5      .��5      �� $	��650��6   $	��500��6    � 	Resources 5   
   3  -System.Windows.Media.Effects.DropShadowEffect   MouseOverDropShadowEffect   	Direction   Opacity   ShadowDepth	   Color��%h   &	          5      $	 320Q�5      $ 80Q�5      $ 10Q�5      $	 	PeachPuff��5      5      .+�5   
   F� -   5        $��UIPath��5      $	��650��5      $	��500��5       ���#EADDCA
 �� Stretch$

 Fill=�5"      
�������$��2��5$      ��5%      B� 5&      .��5'      E�  E� 
StartPoint$
 10,0&�6!   .��5(      ��  �� 
IsLargeArc .   �� Point$
 0,10&�5*       �� RotationAngle$	 180Q�5+       �� Size$ 10,10��5,       �� SweepDirection$ Counterclockwise=�5-      �� 5.       �� Point$ 0,340&�6&   �� 5/       .  $ 10,350&�51      $ 0Q�52      $ 10,10��53      $ Counterclockwise=�54      �� 55      $ 540,350&�6&   �� 56       .  $ 550,340&�58      $	 180Q�59      $ 10,10��5:      $ Counterclockwise=�5;      �� 5<      $ 550,10&�6&   �� 5=       .  $ 540,0&�5?      $	 180Q�5@      $ 10,10��5A      $ Counterclockwise=�5B      5C      5D      5F      � 5H   
   $	��600��5I      $	��450��5J      $��20q�5K       � ColumnDefinitions 5M      �� 5N      $��* �6#   �� 5O      $��* �6#   .+�5R      �� -   5         ��Name$ 
rtfPreview��5S      $��0��5T      $��10q�5U       �� 
IsReadOnly . " �� VerticalScrollBarVisibility$
 Auto=�5W      � 5Y      $��1��6   $��10q�6#    � RowDefinitions 5Z      �� 5[      $��* �6$   �� 5\      $
��Auto �6$   .+�5^      �� $��0��6   $	��Top=�6*   .+�5_      �� $��14(�5`      $
��Bold"�5a      ���#2b1d0e$��Album name:��5c      �� 5d      $��0,0,0,10q�5e      $��14(�5f      ���#2b1d0e$
��Wrap=�5i      ��5h      �� *	AlbumName+5i      �� 5k      $��14(�5l      $
��Bold"�5m      ���#2b1d0e$��Published year:��5o      �� 5p      $��0,0,0,10q�5q      $��14(�5r      ���#2b1d0e��5t      �� *PublishedYear+�� 5v      $��14(�5w      $
��Bold"�5x      ���#2b1d0e$��Date of adding:��5z      �� 5{      $��0,0,0,10q�5|      $��14(�5}      ���#2b1d0e��5      �� *	DateAdded+�� 5�      $	��220��5�      $	��220��5�      $
��Left=�5�      ��5�      �� *PathToImage+5�      �� 5�      -   5         ��Name$ 
ExitButton��5�      $��1��5�      $��80��5�      $��25��5�      $��0,10,0,0q�5�      $��Center=�5�      $��Bottom=�5�      $
��Exit��5�      $��14(�5�      5�      5�      5�      5�      