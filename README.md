# Twin Stick Shooter Multi avec Photon

## Macro Features
- Création et connexion aux salles d'attentes (room)
- Mouvement et rotation synchronisées
- Tirs synchronisés

## Micro Features
- Connexion au serveur de photon
- Connexion aléatoire à une room
- Creation d'une room si aucune n'est disponible
- Feedback de tentative de connexion
- Création synchronisé de salle d'attente
- Création synchronisé de joueur
- Création synchronisé de bullet (gérées localement, mais leur trigger est géré uniquement par le serveur)

## Intentions
L'intention sur le projet était de développer un petit jeu en utilisant un framework de networking haut niveau en correlation avec une architecture ECS (Entity - Component - System).

## Défis
Photon est très étroitement couplé à Unity et une grande partie de ses mécanismes utilise des principes d'unity (MonoBehavior, Système de message, etc...). Or, la mise en place d'une architecture ECS implique de s'éloigner de ces principes. Ainsi, l'utilisation de Photon et Entitas (le framework ECS) a été le challenge le plus important.

## Entitas
Entitas est le framework ECS que j'ai utilisé pour ce projet. Le concept du ECS (Entiy - Component - System) est de séparer les données de la logique de jeu. On retrouve ainsi des entités qui sont des conteneurs à composants. Les composants sont les données en elles-mêmes et enfin les systèmes représentent la logique de jeu qui modifie ces composants et entités.

Entitas permet d'utiliser cette architecture au sein d'Unity. De plus, il propose un générateur de code simplifiant grandement l'API.

Entitas ajoute au concept de ECS plusieurs petits concepts : 

### Les contextes
Dans Entitas, les entity sont réunis dans des contextes. Cela permet de mieux séparer les différentes données mais aussi d'améliorer les performances. Le générateur de code génère notament ces différents contextes mais aussi des raccourcies pour chaque composant qui leur sont associés (à l'aide d'attributs).

### Les groupes
Les groupes sont des ensembles d'entités qui répondent à des critères. Ces groupes sont dynamiques et réactifs (leur contenu s'adapte automatique quand il doit changer). Un groupe est définis au seins d'un contexte. Pour définir un groupe on utilise un Matcher qui est une classe qui décrit les critères du groupe.

### Les collecteurs
Les collecteurs sont des objets qui observent un groupe et qui réagissent à sa modification. Ils sont utilisés pour les reactive systems afin de déterminer quand ces derniers doivent s'executer.

## Les Vues
Afin de bien faire communiquer l'architecture ECS avec le framework d'Unity (et ici de Photon), j'ai utilisé le concept de vue. Les vues sont les éléments qui sont associés avec Unity et qui font le lien avec les entités. Il s'agit le plus souvent de GameObject ou MonoBehavior. Leur but est de servir de point d'input et d'output pour l'architecture ECS. 

Ainsi comme exemple d'input ; les callbacks Unity (ou Photon) comme par exemple OnTriggerEnter sont reçus par une vue (un MonoBehavior) et sont ensuite transférés vers l'ECS.

Ces vues sont stockées dans des composants (GameViewComponent par exemple).

