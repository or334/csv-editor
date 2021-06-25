import { Component, OnInit, ViewChild } from '@angular/core';
import { NgModel } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatTableDataSource } from '@angular/material/table';
import { IPerson } from 'src/app/class/person';
import { IPersonList } from 'src/app/class/person-list';
import { CsvEditorService } from 'src/app/services/csv-editor.service';

@Component({
  selector: 'app-csv-table',
  templateUrl: './csv-table.component.html',
  styleUrls: ['./csv-table.component.scss']
})
export class CsvTableComponent implements OnInit {

  @ViewChild('lastNameInput') lastNameInput: NgModel[];

  displayedColumns: string[] = ['firstName', 'lastName'];
  personsCopy: IPerson[] = [];
  dataSource: MatTableDataSource <IPerson> ;
  isEditMode = false;

  constructor(private _csvService: CsvEditorService,
            private _snackBar: MatSnackBar) { }

  ngOnInit(): void {
    this._initPersons();
  }

  // Get the users list when the component is loading.
  private async _initPersons() {
    this._csvService.getPersons()
    .subscribe( data => {
      this.personsCopy = JSON.parse(JSON.stringify(data));
      this.dataSource = new MatTableDataSource(data);
    })
  }

  toggleEditMode() {
    this.isEditMode = !this.isEditMode;
    console.log(this.isEditMode)
  }

  saveChanges() {
    const emptyFieldsInTable = this.dataSource.data.filter( person => person.firstName.length === 0 || person.lastName.length === 0);
    if (emptyFieldsInTable.length > 0) {
      this._snackBar.open(`You can't have empty fields! Please change and try again.`);
      return;
    }

    const longFields = this.dataSource.data.filter( person => person.firstName.length > 50 || person.lastName.length > 50);
    if (longFields.length > 0) {
      this._snackBar.open(`You can't have a field with more than 50 chars! Please change and try again.`);
      return;
    }
    if (this.arraysEqual(this.dataSource.data, this.personsCopy)) {
      this._snackBar.open(`Please change some data.`);
      return;
    }
    this.personsCopy = this.dataSource.data;
    this._csvService.updatePersons(this.personsCopy);
    this.toggleEditMode();
  }

  arraysEqual(a1,a2) {
    return JSON.stringify(a1)==JSON.stringify(a2);
}

}
