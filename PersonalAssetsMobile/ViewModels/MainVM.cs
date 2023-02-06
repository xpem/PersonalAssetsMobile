﻿using PersonalAssetsMobile.Models;
using PersonalAssetsMobile.Views.Item;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PersonalAssetsMobile.ViewModels
{
    public class MainVM : ViewModelBase
    {
        //  public ObservableCollection<ItemGroup> Items { get; } = new();

        public ObservableCollection<ItemUI> Items { get; } = new();

        public ObservableCollection<Category> Categories { get; } = new();

        ObservableCollection<ItemStatus> itemsStatus;

        public ObservableCollection<ItemStatus> ItemsStatus
        {
            get => itemsStatus; set
            {
                if (itemsStatus != value)
                {
                    itemsStatus = value;
                    OnPropertyChanged();
                }
            }
        }

        Models.ItemUI itemUI;

        public Models.ItemUI ItemUI
        {
            get => itemUI;
            set
            {
                if (itemUI != value)
                {
                    itemUI = value;

                    if (itemUI is not null)
                    {
                        Shell.Current.GoToAsync($"{nameof(ItemForm)}?Key={itemUI.Id}", true);
                    }
                    else
                    {
                        throw new Exception("Id de item nulo");
                    }
                    OnPropertyChanged();
                }
            }
        }

        public ICommand SelectdItemStatusCommand => new Command((e) =>
        {
            var itemStatus = e as ItemStatus;
            ItemsStatus.Where(x => x.Id == itemStatus.Id).First().Name = "Selecionado";

            OnPropertyChanged(nameof(ItemsStatus));

        });

        public MainVM()
        {
            ItemsStatus = new();
            foreach (var _status in ItemsStatusList.itemsStatus)
            {
                ItemsStatus.Add(_status);
            }


            List<Models.ItemUI> listItems = new()
            {
                new Models.ItemUI {
                    Id= 1,
                    Name = "Mesa Retangular Para Sala De Jantar Casa D 120cm Veneza",
                    Category = "Casa>Móveis",
                    CategoryColor = Color.FromArgb("#EF7C8E"),
                    Status="Em uso",
                    SubCategoryIcon="\uf4b8" },
                new Models.ItemUI {
                    Id= 2,
                    Name = "Fogão Atlas Mônaco Top Glass 4 Bocas Preto - Bivolt",
                    Category = "Casa>Eletrodomésticos",
                    CategoryColor=Color.FromArgb("#FAE8E0"),
                    Status="Em uso",
                    SubCategoryIcon= "\uf26c",
                },
                new Models.ItemUI {
                    Id= 3,
                    Name = "Purificador de Água Eletrônico Philco PBE05CF Preto Bivolt",
                    Category = "Casa>Eletroportáteis",
                    CategoryColor=Color.FromArgb("#EF7C8E"),
                    Status="Emprestado",
                    SubCategoryIcon= "\uf517",
                },
                new Models.ItemUI {
                    Id= 4,
                    Name = "Notebook Multilaser PC134",
                    Category = "Casa>Computadores",
                    CategoryColor=Color.FromArgb("#EF7C8E"),
                    Status="Emprestado",
                    SubCategoryIcon = "\uf108"
                },

                new Models.ItemUI {
                    Id= 5,
                    Name = "Smart TV 50\" Crystal UHD 4K Samsung 50BU8000",
                    Category = "Casa>Eletrodomésticos",
                    CategoryColor=Color.FromArgb("#76B947"),
                    Status="Revendido",
                    SubCategoryIcon= "\uf26c",
                },
                new Models.ItemUI {
                    Id= 6,
                    Name = "Samsung Smart TV 32\" LH32BETBLGGXZD LED 2 HDMI 1 USB",
                    Category = "Casa>Eletrodomésticos",
                    CategoryColor = Color.FromArgb("#76B947"), Status="Revendido"
                    ,SubCategoryIcon= "\uf26c" },
                new Models.ItemUI {
                    Id= 7,
                    Name = "Smartphone Samsung Galaxy Note 20", Category = "Celular"
                    ,CategoryColor=Color.FromArgb("#B6E2D3"),Status="Em uso",SubCategoryIcon= "\uf10b" },
                new Models.ItemUI {
                    Id= 8,
                    Name = "Smartphone Samsung Galaxy A52", Category = "Celular",
                    CategoryColor=Color.FromArgb("#B6E2D3"),Status="Revendido",SubCategoryIcon= "\uf10b" },

                new Models.ItemUI {
                    Id= 9,
                    Name = "Colchão Casal Molas Ensacadas com Pillow Top Extra Conforto 138x188x38cm - Premium Sleep - bf Colchões",
                    Category = "Casa>Móveis",CategoryColor=Color.FromArgb("#EF7C8E"),Status="Em uso",SubCategoryIcon="\uf02b" },
                new Models.ItemUI {
                    Id= 10,
                    Name = "Ventilador de Mesa 30cm Mondial VSP-30-B Super Power Preto - 110v",
                    Category = "Casa>Eletroportáteis",CategoryColor=Color.FromArgb("#EF7C8E"),Status="Em uso",SubCategoryIcon="\uf02b" },
                new Models.ItemUI {
                    Id= 11,
                    Name = "Skate Estampado - brink +", Category = "Casa>Esporte",
                    CategoryColor=Color.FromArgb("#D8A7B1"),
                    Status="Guardado",SubCategoryIcon="\uf02b" },
                new Models.ItemUI {
                    Id= 12,
                    Name = "Bola Futebol Campo Oficial Topper Slick Amarelo",
                    Category = "Casa>Esporte",CategoryColor=Color.FromArgb("#D8A7B1"),
                    Status="Emprestado",SubCategoryIcon="\uf02b" },
            };

            foreach (var i in listItems)
            {
                Items.Add(i);
            }
        }



    }
}