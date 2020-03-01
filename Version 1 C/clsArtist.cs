using System;

namespace Version_1_C
{
    [Serializable()] 
    public class clsArtist
    {
        private string _name;
        private string _speciality;
        private string _phone;
   
        private decimal _totalValue;

        private clsWorksList _WorksList;
        private clsArtistList _ArtistList;
        
        private static frmArtist _artistDialog = new frmArtist();
      

        public clsArtist(clsArtistList prArtistList)
        {
            _WorksList = new clsWorksList();
            _ArtistList = prArtistList;
            EditDetails();
        }
        
        public void EditDetails()
        {
            _artistDialog.SetDetails(_name, _speciality, _phone, _WorksList.SortOrder, _WorksList, _ArtistList);
            if (_artistDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
               
                _artistDialog.GetDetails(ref _name, ref _speciality, ref _phone, _WorksList.SortOrder);
                _totalValue = _WorksList.GetTotalValue();
            }
        }

        public string GetKey()
        {
            return _name;
        }

        public decimal GetWorksValue()
        {
            return _totalValue;
        }
    }
}
