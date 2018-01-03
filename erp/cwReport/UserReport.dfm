object frmUserReport: TfrmUserReport
  Left = 799
  Top = 373
  BorderIcons = [biSystemMenu, biHelp]
  BorderStyle = bsSingle
  Caption = #20250#35745#25253#34920
  ClientHeight = 307
  ClientWidth = 503
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  Position = poDesktopCenter
  OnShow = FormShow
  PixelsPerInch = 96
  TextHeight = 13
  object Label1: TLabel
    Left = 8
    Top = 8
    Width = 51
    Height = 13
    Caption = #20250#35745#25253#34920':'
  end
  object Button1: TButton
    Left = 404
    Top = 40
    Width = 75
    Height = 25
    Caption = #26032#24314
    TabOrder = 0
    OnClick = Button1Click
  end
  object Button2: TButton
    Left = 404
    Top = 80
    Width = 75
    Height = 25
    Caption = #25171#24320
    TabOrder = 1
  end
  object Button3: TButton
    Left = 404
    Top = 120
    Width = 75
    Height = 25
    Caption = #21024#38500
    TabOrder = 2
  end
  object Button4: TButton
    Left = 404
    Top = 258
    Width = 75
    Height = 25
    Caption = #20851#38381
    TabOrder = 3
    OnClick = Button4Click
  end
  object DBGridEh1: TDBGridEh
    Left = 8
    Top = 29
    Width = 369
    Height = 263
    AutoFitColWidths = True
    DataSource = DataSource1
    FooterColor = clWindow
    FooterFont.Charset = DEFAULT_CHARSET
    FooterFont.Color = clWindowText
    FooterFont.Height = -11
    FooterFont.Name = 'MS Sans Serif'
    FooterFont.Style = []
    Options = [dgColumnResize, dgColLines, dgRowLines, dgTabs, dgRowSelect, dgAlwaysShowSelection, dgConfirmDelete, dgCancelOnExit]
    ReadOnly = True
    TabOrder = 4
    TitleFont.Charset = DEFAULT_CHARSET
    TitleFont.Color = clWindowText
    TitleFont.Height = -11
    TitleFont.Name = 'MS Sans Serif'
    TitleFont.Style = []
    Columns = <
      item
        EditButtons = <>
        FieldName = 'F_Name'
        Footers = <>
      end>
  end
  object ADOQuery1: TADOQuery
    Connection = ADOConnection1
    Parameters = <>
    SQL.Strings = (
      'select * from t_cwReport')
    Left = 400
    Top = 176
  end
  object DataSource1: TDataSource
    DataSet = ADOQuery1
    Left = 408
    Top = 216
  end
  object ADOConnection1: TADOConnection
    LoginPrompt = False
    Left = 376
    Top = 112
  end
end
