# Gomoku

Generate 15x15 board using POST /api/Game endpoint
When hitting the board use PUT /api/Game/{id}
  -  id of the the player hitting
  -  supply the current board state as payload in body
  -  supply coordinates in "row,column" format as string
  
TODO:
  - Determine who is the winner.
