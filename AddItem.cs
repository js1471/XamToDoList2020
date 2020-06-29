﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace XamToDoList
{
    [Activity(Label = "Add an Item")]
    public class AddItem : Activity
    {
        Button btnAdd;
        EditText txtItemDescription;
        EditText txtItemTitle;

        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.AddItem);

            btnAdd = FindViewById<Button>(Resource.Id.btnAdd);
            txtItemTitle = FindViewById<EditText>(Resource.Id.txtItemTitle);
            txtItemDescription = FindViewById<EditText>(Resource.Id.txtItemDescription);

            btnAdd.Click += onBtnAdd_Click;



        }

        private void onBtnAdd_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtItemDescription.Text != "" && !string.IsNullOrEmpty(txtItemTitle.Text))
                {

                    DatabaseManager.AddItem(txtItemTitle.Text, txtItemDescription.Text);
                    Toast.MakeText(this, "Note was Added", ToastLength.Long).Show();
                    this.Finish();
                    StartActivity(typeof(MainActivity));
                }
            }
            catch (Exception)
            {
                Toast.MakeText(this, "Note was not Added", ToastLength.Long).Show();
                this.Finish();
                StartActivity(typeof(MainActivity));


            }
        }
    }
}