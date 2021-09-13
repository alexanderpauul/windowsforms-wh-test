using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinCSVTest.Services;
using WinCSVTest.Views;

namespace WinCSVTest.Presenters
{
    public class MainFormPresenter
    {
        private IMainForm _dataFormView;
        public MainFormPresenter(IMainForm dataFormView)
        {
            _dataFormView = dataFormView;
        }

        public void LoadData(string path)
        {
            var dt = DataService.ConvertCsvToDataTable(path);
            _dataFormView.Path = path;
            _dataFormView.BindData(dt);
        }

        public void SaveChanges(DataTable data, string path)
        {
            DataService.SaveChangeCSV(data, path);
            LoadData(path);
        }

        public void LoadCombo()
        {
            var data = DataService.GetClassifications();
            _dataFormView.BindCombo(data);
        }

        public void IsAlphanumeric(string value)
        {
            _dataFormView.IsAlphanumeric = DataService.IsNumericOrDate(value);
        }

        public void RewriteValue(string value, string replece, string replacement)
        {
            _dataFormView.RewriteValue = DataService.RewriteValue(value, replece, replacement);
        }

    }
}
