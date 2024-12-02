function validSolution(board) {
  for (let i = 0; i < 9; i++) {
    let row = board[i];
    let column = board.map(row => row[i]);

    if (!isValidSet(row) || !isValidSet(column)) {
      return false;
    }
  }

  for (let blockRow = 0; blockRow < 9; blockRow += 3) {
    for (let blockCol = 0; blockCol < 9; blockCol += 3) {
      let block = extractBlock(board, blockRow, blockCol);
      if (!isValidSet(block)) {
        return false;
      }
    }
  }

  return true;
}

function isValidSet(arr) {
  return new Set(arr).size === 9 && arr.reduce((sum, num) => sum + num, 0) === 45;
}

function extractBlock(board, startRow, startCol) {
  let block = [];
  for (let i = startRow; i < startRow + 3; i++) {
    for (let j = startCol; j < startCol + 3; j++) {
      block.push(board[i][j]);
    }
  }
  return block;
}
