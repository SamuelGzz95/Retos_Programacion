# Hash table de temas con sus rangos de problemas
$temas = @{
    "01-Arrays-Strings"      = 15
    "02-Linked-Lists"        = 5
    "03-Trees-BST"           = 10
    "04-Dynamic-Programming" = 13
    "05-Graphs-BFS-DFS"      = 8
    "06-Backtracking"        = 4
    "07-Sorting-Searching"   = 5
    "08-Design-System"       = 8
    "09-Advanced-Topics"     = 7
}

$lenguajes = @("C#", "TypeScript", "Python")

# Crear estructura para cada tema
foreach ($topic in $temas.Keys | Sort-Object) {
    $problems = $temas[$topic]
    
    New-Item -ItemType Directory -Path $topic -Force | Out-Null
    
    For ($i = 1; $i -le $problems; $i++) {
        $path = "$topic\Reto_$i"
        New-Item -ItemType Directory -Path $path -Force | Out-Null
        #Crear readme en path
        $readmePath = Join-Path $path "README.md"
        $content = ""
        Set-Content -Path $readmePath -Value $content
        foreach ($lang in $lenguajes) {
            $langPath = "$path\$lang"
            New-Item -ItemType Directory -Path $langPath -Force | Out-Null
        }
    }
}