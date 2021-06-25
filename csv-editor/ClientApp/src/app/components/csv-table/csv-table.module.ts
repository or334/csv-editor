import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CsvTableComponent } from './csv-table.component';
import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import {MatInputModule} from '@angular/material/input';
import { FormsModule } from '@angular/forms';
import { MatSnackBarModule } from '@angular/material/snack-bar';

@NgModule({
  declarations: [
    CsvTableComponent
  ],
  exports: [
    CsvTableComponent
  ],
  imports: [
    CommonModule,
    FormsModule,

    MatTableModule,
    MatButtonModule,
    MatInputModule,
    MatSnackBarModule,
  ]
})
export class CsvTableModule { }
