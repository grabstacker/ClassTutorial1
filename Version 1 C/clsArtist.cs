using System;

namespace Version_1_C
{
    [Serializable()] 
    public class clsArtist
    {
        private string _name;
        private string _speciality;
        private string _phone;
        
        private decimal _TotalValue;

        private clsWorksList _WorksList;
        private clsArtistList _ArtistList;
        
        private static frmArtist _artistDialog = new frmArtist();
        private byte _sortOrder;

        public clsArtist(clsArtistList prArtistList)
        {
            _WorksList = new clsWorksList();
            _ArtistList = prArtistList;
            EditDetails();
        }
        
        public void EditDetails()
        {
            _artistDialog.SetDetails(_name, _speciality, _phone, _sortOrder, _WorksList, _ArtistList);
            if (_artistDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _artistDialog.GetDetails(ref _name, ref _speciality, ref _phone, ref _sortOrder);
                _TotalValue = _WorksList.GetTotalValue();
            }
        }

        public string GetKey()
        {
            return _name;
        }

        public decimal GetWorksValue()
        {
            return _TotalValue;
        }
    }
}
