unit UserReport;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, Grids, DBGridEh, DB, ADODB;

type
  TfrmUserReport = class(TForm)
    Button1: TButton;
    Button2: TButton;
    Button3: TButton;
    Button4: TButton;
    DBGridEh1: TDBGridEh;
    Label1: TLabel;
    ADOQuery1: TADOQuery;
    DataSource1: TDataSource;
    ADOConnection1: TADOConnection;
    procedure Button4Click(Sender: TObject);
    procedure Button1Click(Sender: TObject);
    procedure FormShow(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  frmUserReport: TfrmUserReport;

implementation

uses FeaturesMain;

{$R *.dfm}

procedure TfrmUserReport.Button4Click(Sender: TObject);
begin
  Close;
end;

procedure TfrmUserReport.Button1Click(Sender: TObject);
begin
  FeaturesMainForm := TFeaturesMainForm.Create(nil);
  //FeaturesMainForm.NewSheet;
  FeaturesMainForm.ShowModal;
  FeaturesMainForm.Free;
end;

procedure TfrmUserReport.FormShow(Sender: TObject);
begin
  ADOQuery1.Open;
end;

end.
