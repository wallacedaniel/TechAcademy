myList1 = [67, 45, 2, 13, 1, 998]

myList2 = [89, 23, 33, 45, 10, 12, 45, 45, 45]

def sortList(listToSort):
    sortList = []
    while len(listToSort) > 0:
        sortList.append(min(listToSort))
        listToSort.remove(min(listToSort))
    return sortList
        
sortedList1 = sortList(myList1)
print sortedList1

sortedList2 = sortList(myList2)
print sortedList2
