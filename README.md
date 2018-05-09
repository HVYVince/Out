# Out

## Introduction
Out est un logiciel proposant d’enrichir le concept des escape games en utilisant les technologies de réalité augmentée. Le projet utilisera l’Hololens de Microsoft et sa SDK Mixed Reality. Le développement se fera par conséquent en C#.  Le moteur Unity sera également employé afin de profiter de toutes ses fonctionnalités facilitant le développement d’applications 3D.

## Idées Principales
Il y a plusieurs manières d’envisager le logiciel. La plus simple est une collection d’hologrammes placés sur les murs, le sol et le plafond d’une pièce, et formant ensemble l’énigme à résoudre. Ceux-ci seraient totalement indépendant du contexte de la pièce dans laquelle on joue, c’est un simple jeu vidéo jouable chez soi. On peut imaginer un compte à rebours placé sur chacun des 4 murs pour gérer le facteur temps, des claviers à code virtuels, des livres, etc... 

Une version un peu plus poussée est que ces hologrammes soient sensibles à la configuration de la pièce. Ainsi certains ne pourraient fonctionner que sur une table, on pourrait imaginer un canapé qu’il faut pousser pour révéler une “trappe” virtuelle, un explosif à placer contre un mur et qui perce un trou virtuel, etc… Cette version, plus complexe, est plus difficile à mettre en oeuvre car l’Hololens a du mal à distinguer un canapé ou une bibliothèque et ne voit lui qu’un léger relief sur ce qui s’apparente à un plan classique. La détection automatique de l’environnement ne suffit plus, il faudrait que l’utilisateur indique lui même où se trouvent canapés, armoires, fenêtres et autre éléments d’intérêt de la pièce.

La version qui me semble la plus poussée ne peut se jouer que dans des salles spécialement préparées en ce but. Dans ce cas, l’Hololens communique avec un outil distant, un serveur par exemple, et permet de cette façon à des hologrammes de communiquer avec le monde réel. Les possibilités sont alors infinies : la plus évidente serait de déverrouiller la porte sitôt toutes les énigmes résolues, on peut aussi penser à allumer un éclairage de gyrophares rouges lorsqu’il ne reste plus qu’une minute, ouvrir un coffre via une commande vocale destinée à l’hololens, etc…

## Features
Je vais essayer durant ce projet de développer une première énigme jouable chez soi. Celle-ci ne serait composée que d’hologrammes indépendants du contexte, elle serait une version alpha du programme. Dans cette version, le programme contiendra les features suivantes.
* Détection de la position des murs, du sol et du plafond du joueur
Sélection à travers un menu de l’énigme auquel on souhaite participer
* Placement automatique des hologrammes à des positions aléatoires dans la pièce et déclenchement du compte à rebours. Les hologrammes doivent respecter la configuration de la pièce et éviter de traverser tables, armoires et autres meubles.
* Gestion de la victoire lorsque toutes les énigmes sont résolues ou de la défaite lorsque le temps est épuisé
* Création d’une énigme test offrant une dizaine de minutes de jeu.

Ceci fait, il me paraît vraiment très profitable que le projet propose également une interaction avec le monde réel. C’est après tout le principe de la réalité augmentée. Dans cette version, le public serait plutôt composé des propriétaires de salles existantes. En effet, les énigmes virtuelles doivent pouvoir ouvrir des coffres bien réels qui renferment d’autres objets virtuels, et ce principe nécessite l’utilisation de serrures électroniques connectées et d’un système central orchestrant la partie, choses que l’on ne possède pas chez soi. Cette version contiendra les features suivantes.

* Positions des murs, du sol et du plafond définies à l’avance, la salle étant connue.
* Interaction de l’application avec un serveur REST distant, lequel doit pouvoir recevoir des commandes entraînant le déclenchement d’effets dans le monde réel.
* Placement des hologrammes à des positions fixes dans la salle.
* Pas de menu : le compte à rebours commence dès l’entrée dans la salle.
* Création d’une énigme test offrant une dizaine de minutes de jeu et simulant les événements supposés se passer dans le monde réel.
