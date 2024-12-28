## Planet: Null - Black_Box
### Access Point Definitions
Unity Host - Computer on which host game instance is running
Unity Player - Any computer on which the game is being played
Black Box Server - Computer on which the host server is running (not necessarily the computer on which the Unity Host instance is running)
Black Box User - User program that interfaces the Black Box protocol with the game.

### Network Access Pseudo-Map
Unity_host - Start black_box_server
Unity_player - Start black_box_user
Unity_player - Tell black_box_user to ping IP set by player on port #####.
Black_box_server - Await user pings. Once pings are received, it lists the IPs into memory and assigns them there starting map positions
Unity_host - Host starts game starting following loop:
Unity_Server - Create SQLite DB containing hex codes in each square corresponding to the state of each tile
Unity_server - Create SQLite DB containing the coordinate positions of the player
Black_box_server - Read DBs
Black_box_server - Send IP list a signal suggesting that they request the DBs
Black_box_server - Await signal on same port as above requesting the DBs
Black_box_user - Request DBs and await there arrival
Black_box_server - Send the DBs to all IPs that requested the DBs
Black_box_user - Receive DBs and pass them to Unity_host
Unity_host - Convert DB to game map and update current map
Black_box_server - Repeat loop, unless terminated by unity_host
