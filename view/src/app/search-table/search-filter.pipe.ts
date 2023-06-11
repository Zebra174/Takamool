import {Pipe,PipeTransform  } from '@angular/core';

@Pipe({
    name: "searchFilter"
})

export class SearchFilterPipe implements PipeTransform {
  transform(value: any, searchText:string) {
    if(!value) return null;
    if(!searchText) return value;

    searchText = searchText.toLowerCase();

    debugger;

    return value.filter(function(item: any){
      return JSON.stringify(item).toLowerCase().includes(searchText);
    })
  }

}
