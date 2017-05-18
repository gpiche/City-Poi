using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityPoi.Entities;

namespace CityPoi.DataAccesLayer
{
    public static class ApiDbContextExtension
    {
        public static void EnsureSeedDataForContext(this ApiDbContext apiDbContext)
        {
            if (!apiDbContext.Users.Any())
            {
                var user = new User()
                {
                    Username = "admin",
                    Password = "8C6976E5B5410415BDE908BD4DEE15DFB167A9C873FC4BB8A81F6F2AB448A918",
                    Role = "Administrateur"
                };
                apiDbContext.Users.AddRange(user);
                apiDbContext.SaveChanges();
            }

            if (apiDbContext.Cities.Any())
            {
                return;
            }

            var cities = new List<City>()
            {
                new City()
                {
                    Name = "Québec",
                    Country = "Canada",
                    Description = "Ville renomé pour sa poutine",

                },
                new City()
                {
                    Name = "New-York",
                    Country = "États-Unis",
                    Description = "Connu aussi sous le nom de la grosse pomme",

                },
                new City()
                {
                    Name = "Paris",
                    Country = "France",
                    Description = "Ville lumineuse et romantique",

                },
                new City()
                {
                    Name = "Kuala Lumpur",
                    Country = "Malaisie",
                    Description = "Capitale de la Malaisie"
                }
            };

            cities[0].PointsOfInterests.Add(new PointOfInterest()
            {
                Name = "Château Frontenac",
                Descritption = "Emblème de la ville",
                FullDescritption ="Le Château Frontenac a été nommé ainsi en l'honneur de Louis de Buade, comte de Frontenac, qui fut gouverneur de Nouvelle-France de 1672 à 1682 et de 1689 à 16981.L'hôtel est situé dans la Haute-Ville de l'arrondissement historique du Vieux - Québec.Il domine le cap Diamant et sa situation sur la terrasse Dufferin offre un panorama sur le fleuve Saint - Laurent.Outre la terrasse,l'hôtel est bordé au nord par la rue Saint-Louis et au sud par la rue Mont-Carmel d'autres bâtiments occupent le même quadrilatère fermé par la rue Haldimand à l'ouest. La place d'Armes s'étend au nord et la place des Gouverneurs au sud. La rue des carrières et la terrasse Dufferin relient le château à la citadelle de Québec, au sud. Face au château, un funiculaire relie le quartier Petit Champlain.Le château a été construit non loin du lieu historique de la citadelle de Québec, à l'emplacement de l'ancien château Haldimand et à côté de la terrasse Dufferin recouvrant le site archéologique du fort et du château Saint - Louis.",
                Logo = "http://parislanuit.fr/wp-content/uploads/2014/09/chateau-frontenac.png",
                Picture = "http://www.lesventes.ca/media_library/Shopico-Chateau-Frontenac-thumbnail-8fev2016_flyer_top_crop.jpg",
                Latitude = "46.8114843",
                Longitude = "-71.20519279999996"
            });

            cities[0].PointsOfInterests.Add(new PointOfInterest()
            {
                Name = "Chute-Montmorency",
                Descritption = "Plus belles chutes de Quebec",
                FullDescritption = "La chute Montmorency (parfois chutes, au pluriel) est une chute d'eau située à l'embouchure de la rivière Montmorency, où celle-ci se déverse par le rivage en falaise dans le fleuve Saint-Laurent, vis-à-vis de l'extrémité ouest de l'Île d'Orléans. Elle est administrativement partagée entre la ville de Québec et la municipalité de Boischatel. La chute, d'une hauteur de 83 mètres, est la plus haute de la province du Québec et dépasse de trente mètres les chutes du Niagara. La profondeur du bassin au pied de la chute est de dix-sept mètres.La chute est située à l'intérieur du Parc de la Chute-Montmorency, centre touristique géré par la SÉPAQ. Des escaliers (487 marches) permettent de l'observer sous différents angles.Un pont suspendu offrant un point de vue spectaculaire relie les deux côtés du parc.Il y a également un téléphérique qui transporte les visiteurs entre la base et le sommet de la chute.L'hiver, les vapeurs d'eau se solidifient en périphérie de la chute qui devient alors un site populaire d'escalade sur glace en plus de créer une importante masse de glace (le pain de sucre) devant la chute.",
                Logo = "http://www.viaferrataquebec.com/media/cache/a3/9c/a39c5cb65149f2f62a1cdd51fac7d763.jpg",
                Picture = "https://tce-live2.s3.amazonaws.com/media/media/4827f7c5-80f6-48f2-af67-f2a0b4146bbd.jpg",
                Latitude = "46.890804",
                Longitude = "-71.14768400000003"
            });

            cities[0].PointsOfInterests.Add(new PointOfInterest()
            {
                Name = "Musée national des beaux-art",
                Descritption = "La destination parfaite pour les amoureux de l'art",
                FullDescritption = "Le musée national des beaux-arts du Québec (MNBAQ) est situé sur la Grande Allée Ouest en bordure du parc des Champs-de-Bataille à Québec. Il a pour mission «de faire connaître, de promouvoir et de conserver l'art québécois de toutes les périodes, de l'art ancien à l'art actuel, et d'assurer une présence de l'art international par des acquisitions, des expositions et d'autres activités d'animation»7. La collection permanente du musée compte plus de 39 000 œuvres(peintures, sculptures, dessins, photographies, estampes et objets d’art décoratif),essentiellement produites au Québec ou par des artistes québécois,et dont certaines remontent au xviie siècle.Depuis 1987,le musée abrite une bibliothèque en ses murs.Un jardin de sculptures composé de 15 œuvres – Le jardin de sculptures Julie et Christian Lassonde – borde le musée.On peut y voir,entre autres,des sculptures de Jean - Paul Riopelle,Claude Tousignant,Armand Vaillancourt,Charles Daudelin,Jean - Pierre Morin et Ludovic Boney.",
                Logo = "https://s-media-cache-ak0.pinimg.com/564x/35/6f/c1/356fc17d4247e2bbad6d21bea168a396.jpg",
                Picture = "http://res.cloudinary.com/simpleview/image/upload/c_fill,h_910,q_45,w_1206/crm/quebec/photo-Musee_National_Beaux_Arts_Quebec-2_3ce0e999-5056-a36a-075b1763accb3421.jpg",
                Latitude = "46.8009687",
                Longitude = "-71.22502739999999"
            });

            cities[1].PointsOfInterests.Add(new PointOfInterest()
            {
                Name = "Statue de la liberté",
                Descritption = "Embleme principal de la ville",
                FullDescritption = "La Liberté éclairant le monde1 (Liberty Enlightening The World), plus connue sous le nom de Statue de la Liberté (Statue Of Liberty), est l'un des monuments les plus célèbres des États-Unis. Cette statue monumentale est située à New York, sur l'île Liberty Island, au sud de Manhattan, à l'embouchure de l'Hudson et à proximité d'Ellis Island.Elle fut construite en France et offerte par le peuple français,en signe d'amitié entre les deux nations, pour célébrer le centenaire de la Déclaration d'indépendance américaine.La statue fut dévoilée au grand jour le 28 octobre 1886 en présence du président des États - Unis, Grover Cleveland.L'idée venait du juriste et professeur au Collège de France Édouard de Laboulaye, en 1865. Le projet fut confié, en 1871, au sculpteur français Auguste Bartholdi. Pour le choix des cuivres devant être employés à la construction, l'architecte Eugène Viollet - le - Duc eut l'idée de la technique du repoussé. En 1879, à la mort de Viollet-le-Duc, Bartholdi fit appel à l'ingénieur Gustave Eiffel pour décider de la structure interne de la statue.Ce dernier imagina un pylône métallique supportant les plaques de cuivre martelées et fixées. La statue fait partie des National Historic Landmarks depuis le 15 octobre 1924 et de la liste du patrimoine mondial de l'UNESCO depuis 19842.",
                Logo = "http://artsdeszifs.com/705-thickbox_default/sticker-statue-de-la-liberte-2.jpg",
                Picture = "http://www.nyc.fr/wp-content/uploads/2015/07/statue_liberte2.jpg",
                Latitude = "40.6892494",
                Longitude = "-74.0445004"
            });

            cities[1].PointsOfInterests.Add(new PointOfInterest()
            {
                Name = "Time Square",
                Descritption = "La petite jungle de New York, plusieurs spectacles y sont donnés",
                FullDescritption = "Times Square est un quartier de la ville de New York, situé dans l\'arrondissement de Manhattan, qui tire son nom de l\'ancien emplacement du siège du New York Times. Situé entre la 42e rue et Broadway, il comprend les blocs (pâtés d\'immeubles) situés entre la Sixième et la Neuvième Avenue d\'est en ouest, d\'une part, et les blocs entre les 39e à 52e rue du sud au nord d\'autre part. Il constitue la partie ouest du quartier commerçant de Midtown.\r\n\r\nSurnommé « Crossroads of the world1 », Times Square est l\'un des endroits les plus célèbres et les plus animés au monde, à l\'instar de Shibuya à Tokyo, des Champs-Élysées à Paris ou de Piccadilly Circus à Londres : environ 365 000 personnes s\'y croisent chaque jour2.",
                Logo = "https://dcassetcdn.com/design_img/31919/60110/60110_834104_31919_thumbnail.jpg",
                Picture = "http://www.voyage-sponsorise.com/wp-content/uploads/2017/03/e620904e40065de136fafe993c24b176.jpg",
                Latitude = "40.759011",
                Longitude = "-73.98447220000003"
            });

            cities[1].PointsOfInterests.Add(new PointOfInterest()
            {
                Name = "Chinatown",
                Descritption = "Quartier asiatique dans le sud de Manhattan",
                FullDescritption = "Chinatown est un quartier asiatique situé dans le sud de l\'arrondissement de Manhattan, à New York. À l\'exemple d\'autres Chinatowns (quartiers chinois), celui de New York constitue une enclave ethnique peuplée d\'immigrants chinois. Depuis quelques années, la communauté chinoise du quartier de Flushing, dans l\'arrondissement de Queens, moins connue, est devenue plus nombreuse.",
                Logo = "http://www.chinatowncamborne.co.uk/masterpages/images/logo.png",
                Picture = "http://www.partir-a-new-york.com/wp-content/uploads/2012/12/chinatown-manhattan-new-york.jpg",
                Latitude = "40.7157509",
                Longitude = "-73.99703069999998"
            });

            cities[2].PointsOfInterests.Add(new PointOfInterest()
            {
                Name = "Le Sacré coeur",
                Descritption = "L'un des plus beaux monuments de Paris dans le quartier de Montmartre",
                FullDescritption = "La basilique du Sacré-Cœur de Montmartre, dite du Vœu national, située au sommet de la butte Montmartre, dans le quartier de Clignancourt du 18e arrondissement de Paris, est un édifice religieux parisien majeur, « sanctuaire de l\'adoration eucharistique et de la miséricorde divine » et propriété de l\'Archidiocèse de Paris1.\r\n\r\nLa construction de cette église, monument à la fois politique et culturel, suit l\'après-guerre de 1870. Elle est déclarée d\'utilité publique par une loi votée le 24 juillet 1873 par l\'Assemblée nationale de 1871. Elle s\'inscrit dans le cadre d\'un nouvel « ordre moral »2 faisant suite aux événements de la Commune de Paris, dont Montmartre fut un des hauts lieux. Avec près de onze millions de pèlerins et visiteurs par an, c\'est le second monument religieux parisien le plus visité après la cathédrale Notre-Dame de Paris3.",
                Logo = "https://img.clipartfest.com/c694c8e75523d62da1491949f4f8b8b6_-sacre-coeur-paris-sacre-coeur-clipart_300-300.jpeg",
                Picture = "http://www.hotelacadie.com/media/upload/thumb---01-27-2016-Wed_56a9069ead6e0_Eliophot.jpeg",
                Latitude = "48.88670459999999",
                Longitude = "2.34310430000005"
            });

            cities[2].PointsOfInterests.Add(new PointOfInterest()
            {
                Name = "Tour Eiffel",
                Descritption = "Célebre tour en fer de Gustave Eiffel, elle est l'emblème de Paris",
                FullDescritption = "La tour Eiffel Prononciation du titre dans sa version originale Écouter est une tour de fer puddlé de 324 mètres de hauteur (avec antennes)o 1 située à Paris, à l’extrémité nord-ouest du parc du Champ-de-Mars en bordure de la Seine dans le 7e arrondissement. Construite par Gustave Eiffel et ses collaborateurs pour l’Exposition universelle de Paris de 1889, et initialement nommée « tour de 300 mètres », ce monument est devenu le symbole de la capitale française, et un site touristique de premier plan : il s’agit du second site culturel français payant le plus visité en 2011, avec 7,1 millions de visiteurs dont 75 % d\'étrangers en 2011, la cathédrale Notre-Dame de Paris étant en tête des monuments à l\'accès libre avec 13,6 millions de visiteurs estimés2 mais il reste le monument payant le plus visité au monde3,note 1. Elle a accueilli son 250 millionième visiteur en 2010.\r\n\r\nD’une hauteur de 312 mètreso 1 à l’origine, la tour Eiffel est restée le monument le plus élevé du monde pendant 41 ans. Le second niveau du troisième étage, appelé parfois quatrième étage, situé à 279,11 m, est la plus haute plateforme d\'observation accessible au public de l\'Union européenne et la deuxième plus haute d\'Europe, derrière la Tour Ostankino à Moscou culminant à 337 m. La hauteur de la tour a été plusieurs fois augmentée par l’installation de nombreuses antennes. Utilisée dans le passé pour de nombreuses expériences scientifiques, elle sert aujourd’hui d’émetteur de programmes radiophoniques et télévisés.",
                Logo = "http://www.color-stickers.com/1829-thickbox_default/sticker-france-ville-de-paris-tour-eiffel.jpg",
                Picture = "http://www.restaurants-toureiffel.com/upload/photos/6642/t15.jpeg",
                Latitude = "48.85837009999999",
                Longitude = "2.2944813000000295"
            });

            cities[2].PointsOfInterests.Add(new PointOfInterest()
            {
                Name = "Moulin Rouge",
                Descritption = "Cabaret mondialement connu pour ses spectacles et ses danseuses",
                FullDescritption = "Le Moulin-Rouge1,2,3, également graphié Moulin Rouge4 (beaucoup plus rarement Moulin rouge), est un cabaret parisien fondé en 1889 par Joseph Oller et Charles Zidler, qui possédaient déjà l\'Olympia. Il est situé sur le boulevard de Clichy dans le 18e arrondissement de Paris, au pied de la butte Montmartre5. Son style et son nom ont été imités et empruntés par d\'autres cabarets dans le monde entier.",
                Logo = "http://st.depositphotos.com/1035449/4992/v/450/depositphotos_49921067-stock-illustration-vector-sketch-of-cityscape-with.jpg",
                Picture = "https://cdn.pariscityvision.com/media/wysiwyg/moulin-rouge-nuit-2.jpg",
                Latitude = "48.8841232",
                Longitude = "2.33225189999996"
            });

            cities[3].PointsOfInterests.Add(new PointOfInterest()
            {
                Name = "Tour Petronas",
                Descritption = "Les tours jumelles Petronas de Kuala Lumpur en Malaisie ont été conçues par l’architecte argentin Cesar Pelli et inaugurées en 1998. ",
                FullDescritption = "long description",
                Logo = "https://upload.wikimedia.org/wikipedia/commons/thumb/8/85/Petronas_Panorama_II.jpg/260px-Petronas_Panorama_II.jpg",
                Picture = "https://upload.wikimedia.org/wikipedia/commons/thumb/8/85/Petronas_Panorama_II.jpg/260px-Petronas_Panorama_II.jpg",
                Latitude = "3.15785",
                Longitude = "101.71165"
            });
            

            apiDbContext.Cities.AddRange(cities);
            apiDbContext.SaveChanges();
        }

    }
}
