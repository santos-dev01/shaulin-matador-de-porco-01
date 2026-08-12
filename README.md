# Unity Top-Down Shooter Prototype

Este diretório contém scripts e instruções para um protótipo top-down em Unity onde o jogador atira em porcos que aparecem na mata.

Arquivos incluídos:
- Assets/Scripts/PlayerController.cs
- Assets/Scripts/Bullet.cs
- Assets/Scripts/Pig.cs
- Assets/Scripts/GameManager.cs

Instruções de uso (resumo):
1. Crie um novo projeto 2D no Unity (recomendo Unity 2020+ / 2021+).
2. Crie uma cena "TopDownScene".
3. Crie: uma GameObject "Player" com um SpriteRenderer, Rigidbody2D (Body Type: Dynamic, Freeze Rotation Z), Collider2D (Circle/Box) e tag "Player". Adicione o script PlayerController.
   - Crie um child vazio "FirePoint" posicionado na frente do jogador e atribua em PlayerController.firePoint.
   - Atribua um prefab de Bullet em PlayerController.bulletPrefab (ver passos abaixo).
4. Crie um prefab "Bullet": GameObject com SpriteRenderer, Rigidbody2D (Body Type: Dynamic, Gravity Scale = 0), Collider2D (Circle) com IsTrigger marcado, e o script Bullet.
5. Crie um prefab "Pig": GameObject com SpriteRenderer, Rigidbody2D (Body Type: Dynamic, Freeze Rotation Z), Collider2D (Circle/Box), tag "Pig" e o script Pig.
6. Crie um GameObject vazio "GameManager" e adicione o script GameManager. Atribua o prefab Pig e o Player ao GameManager. Crie um UI Text para mostrar Score e um painel para GameOver, atribua em GameManager.
7. Ajuste valores (velocidades, spawnInterval, vida) nos componentes via Inspector conforme desejar.

As scripts são simples e comentadas; veja os arquivos em Assets/Scripts.

Boa base para expandir: sprites, animações, efeitos, sons, armas diferentes, IA dos porcos, power-ups, etc.
