   M S B A M L   `   `   `  ���� N  JHomeOffice.Calendar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:HomeOffice.CalendarHomeOffice.Calendar  O,clr-namespace:HomeOffice.Calendar.ViewModelsHomeOffice.Calendar.ViewModels  F BMVVM.Helper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null^>clr-namespace:MVVM.Helper.ConverterHelper;assembly=MVVM.HelperMVVM.Helper.ConverterHelper $    HomeOffice.Calendar.MainWindow   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     3local!clr-namespace:HomeOffice.Calendar     C
viewmodels,clr-namespace:HomeOffice.Calendar.ViewModels     Qlocal1>clr-namespace:MVVM.Helper.ConverterHelper;assembly=MVVM.Helper       � Title$  HomeOffice Callendar��$	��420��$	��800��$	��420��$	��800�� � Icon$ favicon.ico��.��� $��10q�
������� � ColumnDefinitions �� $��1* ��� $��1* ��� $��1* ��� $��1* ��� $��1* ��� $��1* ��� $��1* ��� $��1* ��� $��1* ��� $��1* ��� $��1* � � RowDefinitions �� $��50 ��� $��50 ��� $��50 ��� $��50 ��� $��50 ��� $��50 ��� $��50 �.+�� $��0��$��3��.+��� 
�������
�������$��1q�._��� $!��Wählen Sie bitte ein Datum��$��Center=�$��15(�$��Center=�� $��0��$��3��.+��� 
�������
�������$��1q�._��� $��Urlaub��$��Center=�$��15(�$��Center=�� $��0��$��4��.+��� 
�������
�������$��1q�._��� $��Krankentage��$��Center=�$��15(�$��Center=�� $��0��$��5��.+��� 
�������
�������$��1q�._��� $��Feiertag��$��Center=�$��15(�$��Center=�� $��0��$��6��$��7��.+��� 
�������
�������$��1q�._��� $��Home Office porzent %��$
��Left=�$��15(�$��Center=�� $��0��$��1��$��3��.+�(  "System.Windows.Controls.DatePicker  -     Name$ DataPicker_Calendar��$��Center=�
���  ��   SelectedDateFormat$ Short=�   FirstDayOfWeek$ Monday=� � ToolTip$* $Datum für den Beginn der Berechnung��   SelectedDate �� *DateDataPicker+� $��1��$��3��.+��� -   	 ��Name$	 Holiday_textBox��$��20��$��50��
 �� 	MaxLength$
 2��$��Center=�$��Center=�$ Tage des Urlaubs genommen������ *HolidayTextBox+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�.��� $��1��$��4��.+��� -   $	 SickDay_textBox��$��20��$��50��$
 2��$��Center=�$��Center=�$! Krankheitsbedingte Fehltage������ *SickDayTextBox+$ TwoWay=�$ PropertyChanged=�.��� $��1��$��5��.+��� -   $	 PublicHoliday_textBox��$��20��$��50��$
 2��$��Center=�$��Center=�$2 ,Eingetragene Feiertage des jeweiligen Monats������ *PublicDayTextBox+$ TwoWay=�$ PropertyChanged=�.��� $��1��$��6��.+��� -    ��Name$ Percentual_Combobox��$��20��$��50��$5 /Prozentsatz der für Homeoffice gewährten Tage�� �� SelectedValue �� *SelectedPercentComboBox+$ TwoWay=�$ PropertyChanged=�   IntToComboBoxItemConverter �� 	Converter# [  .@��� $��10��
 � Tag$ 10���� $��20��$ 20���� $��30��$ 30���� $��40��$ 40���� $��50��$ 50���� $��60��$ 60���� $��80��$ 80���� $��90��$ 90��� $��6��$��10��.+��� -    ��Name$ Submit_Button_2��$��40��$��50��$	��Add��
���   ����� *SubmitCommand+� $��6��$��9��.+��� -   $ Delete_Button��$��40��$��50��$��Delete��
���   ����� *DeleteCommand+� $��3��$��1��$y�	Collapsed=�.+��� -   $	 WorkDay_textBox��$��20��$��50��$
 2��$��Center=�$��Center=� �� 
IsReadOnly$
 True������ *WorkdayTextBox+$ OneWay=�$ PropertyChanged=�.��� $��4��$��1��$y�	Collapsed=�.+��� -	   $	 HomeOffice_textBox��$��20��$��50��$
 2��$��Center=�$��Center=�$
 True������ *HomeOfficeTextBox+$ OneWay=�$ PropertyChanged=�.��� $��5��$��1��$y�	Collapsed=�.+��� -
   $	 InOffice_textBox��$��20��$��50��$
 2��$��Center=�$��Center=�$
 True������ *DayInOfficeTextBox+$ OneWay=�$ PropertyChanged=�.��� $��3��$��0��$y�	Collapsed=�.+��� 
��� � �
�������$��1q�._��� $��Werktag��$��Center=�$��12(�$��Center=�� $��4��$��0��$y�	Collapsed=�.+��� 
��� ���
�������$��1q�._��� $��
HomeOffice��$��Center=�$��12(�$��Center=�� $��5��$��0��$y�	Collapsed=�.+��� 
��� ���
�������$��1q�._��� $��	In Office��$��Center=�$��12(�$��Center=�� $��2��$��4��$��2��$��7��.+��� -    ��Name$ ItemList��$	��Top=�$��5,20,5,0q�$	��180������ *ItemListTable+$ TwoWay=�$ PropertyChanged=� �� SelectedItem �� *SelectedItemTable+ �� View �� .P��� $��HomeOffice Prozent�� �� Width$	 120�� �� DisplayMemberBinding �� *HomeOfficePercent+�� $��Day In HomeOffice��$	 120�� �� *DayInHomeOffice+�� $��Day In Office��$	 100�� �� *DayInOffice+�� $��Month��$	 100�� �� *Date+ �� StringFormat$ 
dd.MM.yyyy��