   M S B A M L   `   `   `  ����   ToolBarStyle    ToolBarStyle.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  
MainWindow��$	��600��$
��1000�� � 	Resources  �� 
TargetType �� Property �� Value �� Triggers P� Property P� Value   HorizontalScrollBar  VerticalScrollBar  ScrollBarButton �� 
TargetType	 �� CornerRadius  
Background  BorderBrush  	BlueBrush
 �� Path �� RelativeSource �� Triggers �� 
TargetName  ScrollBarThumb  ScrollBarPageButton J� Opacity � RowDefinitions ]� DecreaseRepeatButton ]� Thumb ]� IncreaseRepeatButton � ColumnDefinitions  
Foreground �� Color 	 BackgroundBrush��%�	  '��       &	 ?    &	 0    &	 �    &	 u    &	  C    &	 	    &		 ,	    &	 :	    &	 M	    �� " ��.���  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle .  P�  �@��Orientation$ 
Horizontal=�. ���  � ��$
 Auto����  � ��$ 40����  � ��# �   P�  �@��Orientation$ Vertical=�. ���  � ��$ 40����  � ��$
 Auto����  � ��# �  �� " ��.���  �@K�ZIndex$ 1����  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle . ��  � |� .  ��  � ��$ 40����  � ��$ 20����  �@J�Opacity$	 0.7Q���  � �� �� " ��.R��� $��Border��$	 20��#���  #���  $��2q�._�F� $��Center=�$��Center=�#���  ���� $
 Content� �� *TemplatedParent+ P�  � �� . . ��� $ Border�� � ��$ -5q��� $ Border�� �@K�ZIndex$ 99999���� " n�.���  �@K�ZIndex$ 1����  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle . ��  � �� .  ��  � |� .  ��  �@J�Opacity$	 0.7Q���  � �� �� " n�.R��� $��Border��$	 3��#���  
������ $��1q� P�  �@n�
IsDragging . . ��� $ Border��# �   � ���� " ��.���  �@K�ZIndex$ 0����  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle . ��  � �� .  ��  � |� .  ��  � �� �� " ��.R��� #���  $	 3��$	 0.2Q�
������ �� " ��.R��  �� $��40���� $��* ��� $��40��.+��� $��3��
������ 
������ �� $��0��#���  $��40��$��ScrollBar.LineUpCommand��$��M 0 4 L 8 4 L 4 0 Z��]� $��
PART_Track��$��1����.  �� #���  $��9,2,9,2q�$��ScrollBar.PageUpCommand�� n� #���  $��6,1,6,1q� �� #���  $��9,2,9,2q�$��ScrollBar.PageDownCommand���� $��3��#���  $��40��$��ScrollBar.LineDownCommand��$��M 0 0 L 4 4 L 8 0 Z���� " ��.R��  �� $��40���� $��* ��� $��40��.+��� $��3��
������ 
������ �� $��0��#���  $��40��$��ScrollBar.LineLeftCommand��$��M 4 0 L 4 8 L 0 4 Z��]� $��
PART_Track��$��1����.   �� #���  $��2,9,2,9q�$��ScrollBar.PageLeftCommand�� n� #���  $��1,6,1,6q� �� #���  $��2,9,2,9q�$ ��ScrollBar.PageRightCommand���� $��3��#���  $��40��$ ��ScrollBar.LineRightCommand��$��M 0 0 L 4 4 L 0 8 Z���� $ 	LightGray����#ccc����	SteelBlue����	#FF007ACC��.��� -    �Name$ gridMain��#��� 	 .+��� -   #���  $��1q�$	 10, 0, 0, 0��$
��Left=�$��
20,68,0,77q�$��35��#��� 	 ._��� -   .+��� -    ��Name$ buttonUsing�� � ToolTip$ using directive��$�� ��$��25��$��25��$��0, 10, 0, 0q�#���  ��Z� ��Z�  J� OpacityMask ��  �� ImageSource$ img/using.png���� $��0, 10, 0, 0q�$��1��#���  ��Z�  ��  �� EndPoint$	 1,0&� �� 
StartPoint$	 0,0&�.���  � Offset$ 0Q�� $ 1Q��  � Color$ Black��$	 0.2Q�� $ Black��$	 0.8Q��� -   $ buttonNamespace��$ 	namespace��$�� ��$��25��$��25��$��0, 10, 0, 0q�#���  ��Z� ��Z�  �� $ img/namespace.png���� -   $ buttonClass��$ class definition��$�� ��$��25��$��25��$��0, 10, 0, 0q�#���  ��Z� ��Z�  �� $ img/class.png���� -   $ buttonMethod��$ method definition��$�� ��$��25��$��25��$��0, 10, 0, 0q�#���  ��Z� ��Z�  �� $ img/method.png���� -   $ buttonVariable��$ variable��$�� ��$��25��$��25��$��0, 10, 0, 0q�#���  ��Z� ��Z�  �� $ img/variable.png���� $��0, 10, 0, 0q�$��1��#���  ��Z�  �� $	 1,0&�$	 0,0&�.��� $ 0Q�� $ 1Q�� $ Black��$	 0.2Q�� $ Black��$	 0.8Q��� -	   $ buttonCondition��$ if condition��$�� ��$��25��$��25��$��0, 10, 0, 0q�#���  ��Z� ��Z�  �� $ img/condition.png���� -
   $ 
buttonLoop��$ for loop��$�� ��$��25��$��25��$��0, 10, 0, 0q�#���  ��Z� ��Z�  �� $ img/loop.png���� -   #���  $��1q�$	 0, 0, 10, 10��$��
20,0,10,42q�#��� 	 $��35��$��Bottom=�._��� -    �� Orientation$ 
Horizontal=�.+��� #���  $��Center=�$��Center=�$��46��.��var1�� #���  $��Center=�$��Center=�$��46��.��var2�� #���  $��Center=�$��Center=�$��46��.��var3�� #���  $��1q�$��55,68,10,77q�$	 0, 10, 0, 0��._��� -    ��Name$ scrollViewerDropZone��$��10q���Z� .���� -     ��Name$  stackPanelDropZone��$��
0, 0, 0, 0q�#��� 	 ! J� 	AllowDrop! . �� #���  $
��Left=�$	��108��$��	15,86,0,0q�#���  $	��Top=�$��5���� #���  $
��Left=�$��	38,0,0,37q�#���  $	��145��$��5��$��Bottom=��� #���  $
��Left=�$��
188,0,0,37q�#���  $	��145��$��5��$��Bottom=��� $
��Left=�$��68��$	��Top=�$��68��$��img/logo.png��$
��Fill=�