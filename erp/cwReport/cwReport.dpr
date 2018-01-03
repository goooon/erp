library cwReport;

{ Important note about DLL memory management: ShareMem must be the
  first unit in your library's USES clause AND your project's (select
  Project-View Source) USES clause if your DLL exports any procedures or
  functions that pass strings as parameters or function results. This
  applies to all strings passed to and from your DLL--even those that
  are nested in records and classes. ShareMem is the interface unit to
  the BORLNDMM.DLL shared memory manager, which must be deployed along
  with your DLL. To avoid using BORLNDMM.DLL, pass string information
  using PChar or ShortString parameters. }

uses
  SysUtils,
  Classes,
  FeatureChild in 'FeatureChild.pas' {FeatureChildForm},
  FeatureModify in 'FeatureModify.pas' {FeatureModifyForm},
  FeaturesMain in 'FeaturesMain.pas' {FeaturesMainForm},
  UserReport in 'UserReport.pas' {frmUserReport};

{$R *.res}

function ShowUserReport(handle: THandle;strCon :PChar):Integer;stdcall;
begin
  frmUserReport := TfrmUserReport.Create(nil);
  frmUserReport.ADOConnection1.ConnectionString := strCon;
  frmUserReport.ShowModal;
  frmUserReport.Free;
end;

//dllº¯Êý½Ó¿Ú
Exports
    ShowUserReport;
    
begin

end.
