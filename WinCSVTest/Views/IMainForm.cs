using System.Collections.Generic;
using System.Data;
using WinCSVTest.Models;

namespace WinCSVTest.Views
{
    public interface IMainForm
    {
        string Path { get; set; }

        int SelectedValue { get; set; }

        bool IsAlphanumeric { get; set; }

        string RewriteValue { get; set; }

        void BindData(DataTable dt);

        void BindCombo(List<WHClassification> listValues);
    }
}
